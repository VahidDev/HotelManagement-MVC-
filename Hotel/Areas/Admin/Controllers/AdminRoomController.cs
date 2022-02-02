using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Constants;
using Hotel.Constants.MessageConstants;
using Hotel.Constants.POCOConstants;
using Hotel.DAL;
using Hotel.Models;
using Hotel.Utilities.ControllerUtilities.AdminHotelUtilities;
using Hotel.Utilities.ControllerUtilities.AdminRoomUtilities;
using Hotel.Utilities.FileUtilities;
using Hotel.ViewModels.AdminViewModels.AdminRoomViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(DefaultRoleConstants.Admin) + ","
    + nameof(DefaultRoleConstants.Hotel))]
    public class AdminRoomController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminRoomController(AppDbContext dbContext, UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [HttpPost]
        public async Task<string> Delete(int id)
        {
            Room room = await _dbContext.Rooms.Include(r => r.Hotel)
                .FirstOrDefaultAsync(r => !r.IsDeleted && r.Id == id);
            if (room == null) return "Not Found";
            if (await _dbContext.Reservations.AnyAsync(r => !r.IsDeleted && r.EndDate > DateTime.Now
             && r.Room.Id == room.Id))
            {
                return "Reservation Error";
            }
            ICollection<RoomImage> roomImages = await _dbContext.RoomImages
                .Where(r => r.Room.Id== room.Id).ToArrayAsync();
            foreach (RoomImage roomImage in roomImages)
            {
                FileDeleter.Delete(FileNameConstants.RoomImage, roomImage.Name);
            }
            room.IsDeleted = true;
            room.Hotel.RoomCount--;
            room.DeletedDate = DateTime.Now;
            _dbContext.Hotels.Update(room.Hotel);
            _dbContext.Rooms.Update(room);
            await _dbContext.SaveChangesAsync();
            return "Success";
        }
        public async Task<IActionResult> Update(int id)
        {
            Room room = await _dbContext.Rooms.Include(r => r.Hotel)
                .Include(r=>r.Facilities.Where(f=>!f.IsDeleted))
                .FirstOrDefaultAsync(r => !r.IsDeleted && r.Id == id);
            if (room == null) return NotFound();
            AdminRoomUpdateViewModel model = await UpdateRoomMapper.MapAsync(room,_dbContext);
            return View(model);
        }
        public async Task<IActionResult>Detail (int id)
        {
            Room room = await _dbContext.Rooms.Include(r=>r.Hotel)
                .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);
            if (room == null) return NotFound();
            return View(new AdminRoomDetailViewModel {
            Room=room,
            HotelName=room.Hotel.Name,
            Comments=await _dbContext.Comments
            .Where(c=>!c.IsDeleted&&c.Room==room).ToListAsync(),
            Reservations= await _dbContext.Reservations.Include(c => c.User)
            .Where(c => !c.IsDeleted && c.Room == room).ToListAsync(),
            HotelId=room.Hotel.Id,
            MainImage=(await _dbContext.RoomImages.FirstOrDefaultAsync(r=>r.Room==room&&r.IsMain)).Name,
            Images= await _dbContext.RoomImages.Where(r => r.Room == room && !r.IsMain)
            .Select(i=>i.Name).ToListAsync()
            });
        }
        [HttpPost]
        public async Task<string> DeleteComment(int id)
        {
            Comment comment =await  _dbContext.Comments.FirstOrDefaultAsync(c => !c.IsDeleted && c.Id == id);
            if (comment == null) return "Not Found";
            comment.IsDeleted = true;
            comment.DeletedDate = DateTime.Now;
            _dbContext.Comments.Update(comment);
            await _dbContext.SaveChangesAsync();
            return "Success";
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AdminRoomUpdateViewModel model,int id)
        {
            Room room = await _dbContext.Rooms.Include(r=>r.Hotel)
                .Include(r=>r.RoomImages).Include(r=>r.Facilities)
                .FirstOrDefaultAsync(r=>r.Id==id&&!r.IsDeleted);
            Models.Hotel hotel = room.Hotel;
            if (room == null) return NotFound();
            if (room.Id != model.RoomId) return BadRequest();
            if (hotel.Id != model.HotelId) return BadRequest();
            ICollection<Facility> allFacilities = await _dbContext.Facilities
                .Where(f => !f.IsDeleted).ToListAsync();
            foreach (FacilityCheckBox facilityCheckBox in model.Facilities)
            {
                Facility facility= allFacilities
                       .FirstOrDefault(f => f.Id == facilityCheckBox.Facility.Id);
                facilityCheckBox.Facility = facility;
               
            }
            if (!model.Facilities.Any(f=>f.Selected))
            {
                ModelState.AddModelError(nameof(AdminRoomUpdateViewModel.Facilities),
                    "En azi 1 facility sechilmelidir!");
                model.Facilities = await FacilityGetter.GetAllFacilities(_dbContext);
            }
            if (!Single.TryParse(model.Price.ToString(), out float priceResult))
            {
                ModelState.AddModelError(nameof(AdminRoomUpdateViewModel.Price),
                    "Daxil Edilen qiymet duzgun deyl");
            }
            if (model.Type.ToString().StartsWith("0"))
            {
                ModelState.AddModelError(nameof(AdminRoomUpdateViewModel.Type),
                    "Daxil Edilen otagin novu duzgun deyil");
            }
            if (model.Price.ToString().StartsWith("0"))
            {
                ModelState.AddModelError(nameof(AdminRoomUpdateViewModel.Price),
                    "Daxil Edilen qiymet duzgun deyil");
            }
            if (model.Type.ToString().StartsWith("0"))
            {
                ModelState.AddModelError(nameof(AdminRoomUpdateViewModel.Type),
                    "Daxil Edilen otagin novu duzgun deyil");
            }
            if (Convert.ToSingle(model.Price) < 10)
            {
                ModelState.AddModelError(nameof(AdminRoomUpdateViewModel.Price),
                    "Daxil Edilen qiymet cox asagidir");
            }
            if (model.Size.ToString().StartsWith("0"))
            {
                ModelState.AddModelError(nameof(AdminRoomUpdateViewModel.Size),
                    "Daxil Edilen otagin olchusu duzgun deyil");
            }
            if (!Int32.TryParse(model.Size.ToString(), out int sizeResult))
            {
                ModelState.AddModelError(nameof(AdminRoomUpdateViewModel.Size),
                    "Daxil Edilen olchu duzgun deyl");
            }
            if (!Byte.TryParse(model.Type.ToString(), out byte typeResult))
            {
                ModelState.AddModelError(nameof(AdminRoomUpdateViewModel.Type),
                    "Daxil Edilen nov duzgun deyl");
            }
            if (!ModelState.IsValid) return View(model);
            ICollection<Facility>facilities= room.Facilities;
            room.Facilities.Clear();
            foreach (FacilityCheckBox facilityCheckBox in model.Facilities)
            {
                if (facilityCheckBox.Selected)
                room.Facilities.Add(facilityCheckBox.Facility);
            }
            if (model.MainImage != null)
            {
                if (!model.MainImage.CheckSizeForMg())
                {
                    ModelState.AddModelError(nameof(AdminRoomUpdateViewModel.MainImage),
                          FileMessageConstants.MgSizeError);
                    return View(model);
                }
                if (!model.MainImage.CheckContentForImg())
                {
                    ModelState.AddModelError(nameof(AdminRoomUpdateViewModel.MainImage),
                         FileMessageConstants.ImageContentError);
                    return View(model);
                }
                Guid guid = Guid.NewGuid();
                FileDeleter.Delete(FileNameConstants.RoomImage, model.MainImageStr);
                await model.MainImage.CreateAsync(guid, FileNameConstants.RoomImage);
                room.RoomImages.FirstOrDefault(r => r.IsMain).Name = guid + model.MainImage.FileName;
            }
            if (model.RoomImages!=null) {
                ICollection<RoomImage> roomImages = room.RoomImages.Where(r => !r.IsMain).ToList();
                foreach (RoomImage roomImage in roomImages)
                {
                    FileDeleter.Delete(FileNameConstants.RoomImage, roomImage.Name);
                }
                _dbContext.RoomImages.RemoveRange(roomImages);
                foreach (IFormFile file in model.RoomImages)
                {
                    if (!file.CheckSizeForMg())
                    {
                        ModelState.AddModelError(nameof(AdminRoomUpdateViewModel.RoomImages),
                            "File Name: " + file.FileName + FileMessageConstants.MgSizeError);
                        return View(model);
                    }
                    if (!file.CheckContentForImg())
                    {
                        ModelState.AddModelError(nameof(AdminRoomUpdateViewModel.RoomImages),
                            "File Name: " + file.FileName + FileMessageConstants.ImageContentError);
                        return View(model);
                    }
                    Guid guid = Guid.NewGuid();
                    await file.CreateAsync(guid, FileNameConstants.RoomImage);
                    await _dbContext.RoomImages.AddAsync(new RoomImage
                    {
                        Room = room,
                        Name = guid + file.FileName,
                        IsMain = false
                    });
                }
            }
            room.Name = model.Name;
            room.Description = model.Description;
            room.Title = model.Title;
            room.Size = model.Size;
            room.Type = model.Type;
            room.Price = model.Price;
            _dbContext.Rooms.Update(room);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(AdminHotelController.Detail),"AdminHotel",new {id=hotel.Id });
        }
        public async Task<IActionResult> Create(int id)
        {
            Models.Hotel hotel = await _dbContext.Hotels.FirstOrDefaultAsync(h => !h.IsDeleted && h.Id == id);
            if (hotel == null) return NotFound();
            List<FacilityCheckBox> facilityCheckBoxes = await FacilityCheckBoxListCreator
                .CreateAsync(_dbContext);
            return View(new AdminRoomCreateViewModel
            {
                Facilities = facilityCheckBoxes.ToArray(),
                HotelId = hotel.Id
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdminRoomCreateViewModel model, int id)
        {
            if (id != model.HotelId) return BadRequest();
            Models.Hotel hotel = await _dbContext.Hotels.FirstOrDefaultAsync(h => !h.IsDeleted && h.Id == id);
            if (hotel == null) return NotFound();
            List<FacilityCheckBox> facilityCheckBoxes = await FacilityCheckBoxListCreator
                .CreateAsync(_dbContext);
            AdminRoomCreateViewModel modelToSend = new()
            {
                Facilities = facilityCheckBoxes.ToArray(),
                HotelId = hotel.Id,
            };
            ICollection<Facility> facilities = new List<Facility>();
            if (!Single.TryParse(model.Price.ToString(), out float priceResult))
            {
                ModelState.AddModelError(nameof(AdminRoomCreateViewModel.Price),
                    "Daxil Edilen qiymet duzgun deyl");
            }
            if (model.Price.ToString().StartsWith("0"))
            {
                ModelState.AddModelError(nameof(AdminRoomCreateViewModel.Price),
                    "Daxil Edilen qiymet duzgun deyil");
            }
            if (Convert.ToSingle(model.Price) < 10)
            {
                ModelState.AddModelError(nameof(AdminRoomCreateViewModel.Price),
                    "Daxil Edilen qiymet cox asagidir");
            }
            if (model.Type.ToString().StartsWith("0"))
            {
                ModelState.AddModelError(nameof(AdminRoomCreateViewModel.Type),
                    "Daxil Edilen otagin novu duzgun deyil");
            }
            if (model.Size.ToString().StartsWith("0"))
            {
                ModelState.AddModelError(nameof(AdminRoomCreateViewModel.Size),
                    "Daxil Edilen otagin olchusu duzgun deyil");
            }
            if (!Int32.TryParse(model.Size.ToString(), out int sizeResult))
            {
                ModelState.AddModelError(nameof(AdminRoomCreateViewModel.Size),
                    "Daxil Edilen olchu duzgun deyl");
            }
            if (!Byte.TryParse(model.Type.ToString(), out byte typeResult))
            {
                ModelState.AddModelError(nameof(AdminRoomCreateViewModel.Type),
                    "Daxil Edilen nov duzgun deyl");
            }
            if (!model.Facilities.Any(f => f.Selected))
            {
                ModelState.AddModelError(nameof(AdminRoomCreateViewModel.Facilities),
                    "En azi bir facility sechilmelidir");
            }
            if (!model.MainImage.CheckSizeForMg())
            {
                ModelState.AddModelError(nameof(AdminRoomCreateViewModel.MainImage),
                    FileMessageConstants.MgSizeError);
            }
            if (!model.MainImage.CheckContentForImg())
            {
                ModelState.AddModelError(nameof(AdminRoomCreateViewModel.MainImage),
                    FileMessageConstants.ImageContentError);
            }
            if (!ModelState.IsValid) return View(modelToSend);
            Guid guid = Guid.NewGuid();
            await model.MainImage.CreateAsync(guid, FileNameConstants.RoomImage);
            ICollection<RoomImage> roomImages = new List<RoomImage>() { new RoomImage {
                IsMain=true,
                Name=guid+model.MainImage.FileName,
            } };
            foreach (IFormFile file in model.RoomImages)
            {
                if (!file.CheckSizeForMg())
                {
                    ModelState.AddModelError(nameof(AdminRoomCreateViewModel.RoomImages),
                        "File Name: " + file.FileName + FileMessageConstants.MgSizeError);
                    return View(modelToSend);
                }
                if (!file.CheckContentForImg())
                {
                    ModelState.AddModelError(nameof(AdminRoomCreateViewModel.RoomImages),
                        "File Name: " + file.FileName + FileMessageConstants.ImageContentError);
                    return View(modelToSend);
                }
                Guid guid1 = Guid.NewGuid();
                await file.CreateAsync(guid1, FileNameConstants.RoomImage);
                roomImages.Add(new RoomImage
                {
                    IsMain = false,
                    Name = guid1 + file.FileName,
                });
            }
            hotel.RoomCount++;
            Room room = new()
            {
                Description = model.Description,
                Title = model.Title,
                Hotel = hotel,
                Price = priceResult,
                Size = sizeResult,
                Name = model.Name,
                Type = typeResult,
                RoomImages = roomImages,
            };
            foreach (FacilityCheckBox facilityCheckBox in model.Facilities)
            {
                if (facilityCheckBox.Selected)
                {
                    facilities.Add(facilityCheckBox.Facility);
                    await _dbContext.Facilities.Include(f => f.Rooms)
                         .Where(f => f.Id == facilityCheckBox.Facility.Id).ForEachAsync(f => {
                             f.Rooms.Add(room);
                         });
                }
            }
            await _dbContext.Rooms.AddAsync(room);
            _dbContext.Hotels.Update(hotel);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(AdminHotelController.Detail),"AdminHotel", new { id });
        }
    }
}
