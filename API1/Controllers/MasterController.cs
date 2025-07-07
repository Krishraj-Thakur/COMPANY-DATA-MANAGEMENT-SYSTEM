using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.Services.Interface;
using AutoMapper;
using API.core.DTO_s;
using API.core.DbModels;
using API.core;

namespace API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IMasterService _masterService;
        private readonly IMapper _mapper;

        // Constructor: Injects the service and AutoMapper
        public MasterController(IMasterService masterService, IMapper mapper)
        {
            _masterService = masterService;
            _mapper = mapper;
        }

        // GET: api/Master

        [HttpGet("GetAllMaterialDescp")]
        public IActionResult Get() {
            var materials = _masterService.GetAllMaterialDescp();
            var dtomaterials = _mapper.Map<IEnumerable<MaterialMasterDTO>>(materials);
            return Ok(dtomaterials); // Return as JSON
        }

        // POST: api/Master/CreateMaterial

        [HttpPost("CreateMaterial")]
        public IActionResult Create([FromBody] MaterialMasterDTO materialDto)
        {
            // Map DTO to entity
            var entity = _mapper.Map<MaterialMaster>(materialDto);
            // Call service to save to DB
            _masterService.CreateMaterial(entity);
            return Ok("Material added.");
        }

        // DELETE: api/Master/DeleteMaterial/{id}

        [HttpDelete("DeleteMaterial/{id}")]
        public IActionResult Delete(int id)
        {
            // Call service to delete by ID
            _masterService.DeleteMaterial(id);
            return Ok("Material deleted.");
        }

        // GET: api/Master/GetAllPurchaseTypes
        [HttpGet("GetAllPurchaseTypes")]
        public IActionResult GetPurchaseTypes()
        {
            var purchaseTypes = _masterService.GetAllPurchaseTypes();
            var dtoPurchaseTypes = _mapper.Map<IEnumerable<PurchaseTypeDTO>>(purchaseTypes);
            return Ok(dtoPurchaseTypes); // Return as JSON
        }
        
    }

}
