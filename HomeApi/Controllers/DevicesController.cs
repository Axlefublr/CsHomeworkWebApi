using AutoMapper;
using HomeApi.Configuration;
using HomeApi.Contracts.Models.Devices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HomeApi.Controllers
{
	/// <summary>
	/// Контроллер статусов устройств
	/// </summary>
	[ApiController]
	[Route("[controller]")]
	public class DevicesController : ControllerBase
	{
		private IOptions<HomeOptions> _options;
		private IMapper _mapper;

		public DevicesController(IOptions<HomeOptions> options, IMapper mapper)
		{
			_options = options;
			_mapper = mapper;
		}

		/// <summary>
		/// Просмотр списка подключенных устройств
		/// </summary>
		[HttpGet]
		[Route("")]
		public IActionResult Get()
		{
			return StatusCode(200, "Устройства отсутствуют");
		}

		/// <summary>
		/// Добавление нового устройства
		/// </summary>
		[HttpPost]
		[Route("")]
		public IActionResult Add(
			[FromBody]
			AddDeviceRequest request
		)
		{
			return StatusCode(200, $"Device {request.Name} added!");
		}
	}
}