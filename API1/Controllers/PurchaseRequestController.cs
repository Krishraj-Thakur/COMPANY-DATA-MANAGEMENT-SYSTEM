using Api.Services.Interface;
using Api.Services.Service;
using API.core.DbModels;
using API.core.DTO_s;
using API.core;

using API1;
using API1.AutoMapper;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseRequestController : ControllerBase
    {
        private readonly IPRService _prService;
        private readonly IMapper _mapper;

        // Constructor: Injects the service and AutoMapper
        public PurchaseRequestController(IPRService prService, IMapper mapper)
        {
            _prService = prService;
            _mapper = mapper;
        }

        // GET: api/PurchaseRequest
        [HttpGet("GetAllRequests")]
        public IActionResult Get()
        {
            // Get all purchase requests from service (as entities)
            var entities = _prService.GetAll();

            // Map entities to DTOs
            var dtoList = _mapper.Map<IEnumerable<PurchaseRequestsDTO>>(entities);

            return Ok(dtoList); // Return as JSON
        }

        // POST: api/PurchaseRequest
        [HttpPost("CreateRequest")]
        public IActionResult Create([FromBody] PurchaseRequestsDTO prDto)
        {
            // Map DTO to entity
            //debugger placement below line 
            var entity = _mapper.Map<PurchaseRequest>(prDto);

            // Call service to save to DB
            _prService.Create(entity);

            return Ok("Purchase Request added.");
        }

        // DELETE: api/PurchaseRequest/{id}
        [HttpDelete("DeleteRequest/{id}")]
        public IActionResult Delete(int id)
        {
            // Call service to delete by ID
            _prService.Delete(id);
            return Ok("Purchase Request deleted.");
        }

        // Transaction handling get, post and delete methods

        [HttpGet("GetAllTransactions")]

        public IActionResult GetAllTransactions()
        {
            // Get all transactions from service
            var entities = _prService.GetAllTr();
            // Map entities to DTOs
            var dtoList = _mapper.Map<IEnumerable<PritemDetailsDTO>>(entities);
            return Ok(dtoList); // Return as JSON
        }

        [HttpPost("CreateTransaction")]

        public IActionResult CreateTransaction([FromBody] PritemDetailsDTO trDto)
        {
            // Map DTO to entity
            var entity = _mapper.Map<PritemDetail>(trDto);
            // Call service to save to DB
            _prService.CreateTransaction(entity);
            return Ok("Transaction added.");
        }

        [HttpDelete("DeleteTransaction/{id}")]

        public IActionResult DeleteTransaction(int id)
        {
            // Call service to delete by ID
            _prService.DeleteTransaction(id);
            return Ok("Transaction deleted.");
        }
    }
}