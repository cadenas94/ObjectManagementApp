using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ObjectManagementApp.DTO;
using ObjectManagementApp.Models;

namespace ObjectManagementApp.Controllers
{
    public class ObjectMController : Controller
    {
        private readonly ApplicationDbContext context;

        public IMapper mapper { get; }

        public ObjectMController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //Return the view to add a new object 
        public IActionResult Create()
        {
            return View();
        }
        //Save a new object in DB
        [HttpPost]
        public async Task<IActionResult> PostValues(ObjectMDTO model)
        {
            var mat = model.Name;
            var quantity = model.Description;
            var type = model.Type;

            var objectM = new ObjectM() { Name = model.Name, Description = model.Description, Type = model.Type };
            //Save in DB the new object created by the user
            context.Add(objectM);
            await context.SaveChangesAsync();
            return RedirectToAction("DataSaved");
        }
        //Show all the data saved in the database
        [HttpGet]
        public async Task<IActionResult> DataSaved()
        {
            var modelo = await context.Objects.ToListAsync();
            var model = mapper.Map<ObjectMListDTO>(modelo);

            return View(model);
        }
        //Return the Edit View
        public async Task<IActionResult> Edit(int id)
        {
            var objectDB = await context.Objects.AsTracking().FirstOrDefaultAsync(a => a.Id == id);

            if (objectDB is null)
            {
                return RedirectToAction("NoEncontrado", "DataSaved");
            }

            var modelo = mapper.Map<ObjectMDTO>(objectDB);

            return View(modelo);
        }
        //Edit any object saved in the DB
        [HttpPost]
        public async Task<IActionResult> EditObject(ObjectMDTO model, int id)
        {
            //Check if the object exists in the DB
            var existObjectDB = await context.Objects.AnyAsync(a => a.Id == id);

            if (!existObjectDB)
            {
                return NotFound();
            }
            //If exists, we map the DTO object
            var objectM = mapper.Map<ObjectM>(model);
            objectM.Id = id;
            //Update the entity context state to udpate the object
            context.Update(objectM);
            await context.SaveChangesAsync();

            return RedirectToAction("DataSaved");
        }
        //Return the remove view
        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            //Check if the object exists in the DB
            var objectDB = await context.Objects.AsTracking().FirstOrDefaultAsync(a => a.Id == id);

            if (objectDB is null)
            {
                return RedirectToAction("NoEncontrado", "DataSaved");
            }

            return View(objectDB);
        }
        //Remove any object from DB
        [HttpPost]
        public async Task<IActionResult> RemoveObject(int id)
        {
            //Check if the object exists in the DB
            var ObjectDB = await context.Objects.FirstOrDefaultAsync(a => a.Id== id);

            if (ObjectDB is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }
            //If exists update the entity context state to remove the object in DB
            context.Remove(ObjectDB);
            await context.SaveChangesAsync();
            return RedirectToAction("DataSaved");
        }
    }
}
