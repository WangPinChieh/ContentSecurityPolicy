using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContentSecurityPolicy.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ContentSecurityPolicy.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			_logger.LogInformation("Test");
			return View();
		}

		[HttpPost]
		public IActionResult LogBlockReport([FromBody]CspReportRequest cspReportRequest)
		{
			_logger.LogInformation(cspReportRequest.ToString());
			return Json(true);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}

	public class CspReportRequest
	{
		[JsonProperty("csp-report")]
		public CspReport CspReport { get; set; }

		public override string ToString()
		{
			return $"{nameof(CspReport)}: {CspReport}";
		}
	}
	public class CspReport
	{
		[JsonProperty("document-uri")] public string DocumentUri { get; set; }
		[JsonProperty("referrer")] public string Referrer { get; set; }
		[JsonProperty("violated-directive")] public string ViolatedDirective { get; set; }
		[JsonProperty("effective-directive")] public string EffectiveDirective { get; set; }
		[JsonProperty("original-policy")] public string OriginalPolicy { get; set; }
		[JsonProperty("blocked-uri")] public string BlockedUri { get; set; }
		[JsonProperty("status-code")] public int StatusCode { get; set; }


		public override string ToString()
		{
			return $"{nameof(DocumentUri)}: {DocumentUri}, {nameof(Referrer)}: {Referrer}, {nameof(ViolatedDirective)}: {ViolatedDirective}, {nameof(EffectiveDirective)}: {EffectiveDirective}, {nameof(OriginalPolicy)}: {OriginalPolicy}, {nameof(BlockedUri)}: {BlockedUri}, {nameof(StatusCode)}: {StatusCode}";
		}
	}

}
