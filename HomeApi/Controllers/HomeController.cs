using AutoMapper;
using HomeApi.Configuration;
using HomeApi.Contracts.Models.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HomeApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class HomeController : ControllerBase
	{
		// Ссылка на объект конфигурации
		private readonly IOptions<HomeOptions> _options;
		private readonly IMapper _mapper;

		// Инициализация конфигурации при вызове конструктора
		public HomeController(IOptions<HomeOptions> options, IMapper mapper)
		{
			_options = options;
			_mapper = mapper;
		}

		/// <summary>
		/// Метод для получения информации о доме
		/// </summary>
		[HttpGet] // Для обслуживания Get-запросов
		[Route("info")] // Настройка маршрута с помощью атрибутов
		public IActionResult Info()
		{
			var infoResponse = _mapper.Map<HomeOptions, InfoResponse>(_options.Value);
			// Преобразуем результат в строку и выводим, как обычную веб-страницу
			return StatusCode(200, infoResponse);
		}
	}
}