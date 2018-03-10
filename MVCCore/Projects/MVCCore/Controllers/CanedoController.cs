using Microsoft.AspNetCore.Mvc;
using System;

namespace MVCCore.Controllers
{
    /// <summary>
    /// Para mais informações:
    /// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/routing#route-constraint-reference
    /// </summary>
    public class CanedoController : Controller
    {
        [HttpGet]
        [Route("Canedo/Main-Page"), Route("", Order = 0)]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult IndexJson()
        {
            return Json("{'Nome':'Canedo'}");
        }

        [HttpGet]
        public IActionResult RedirectToIndex()
        {
            return RedirectToAction("Index");
        }

        //Sample: {server}/Canedo/IndexParameter/1/Flavio/Canedo
        [HttpGet]
        [Route("Canedo/IndexParameter"), 
            Route("Canedo/IndexParameter/{id:int}/{name:alpha}/{lastName:alpha}")]
        public IActionResult IndexParameter(int id, string name, string lastName)
        {
            return
                Json("{" + string.Format("'id':{0}, 'Name':{1}, 'LastName':{2}", id, name, lastName) + "}");
        }

        //Sample: {server}/Canedo/IndexDateTime/2018-03-08 10:41:55pm
        [HttpGet]
        [Route("Canedo/IndexDateTime"),
            Route("Canedo/IndexDateTime/{dateTime:datetime}")]
        public IActionResult IndexDateTime(DateTime dateTime)
        {
            return Json("{" + string.Format("'dateTime':{0}", dateTime) + "}");
        }

        //Sample: {server}/Canedo/IndexNumbers/123456789/49.99/1.234/1.234/123456789/CD2C1638-1638-72D5-1638-DEADBEEF1638
        [HttpGet]
        [Route("Canedo/IndexNumbers"),
            Route("Canedo/IndexNumbers/{_int:int}/{_decimal:decimal}/{_double:double}/{_float:float}/{_long:long}/{guid:guid}")]
        public IActionResult IndexNumbers(int _int, decimal _decimal, double _double, float _float, long _long, Guid guid)
        {
            return
                Json("{" + 
                string.Format(
                    "'int':{0}, 'decimal':{1}, 'double':{2}, 'float':{3}, 'long':{4}, 'Guid':{5}", 
                    _int, _decimal,_double, _float, _long, guid) + "}");
        }

        //Sample: {server}/Canedo/IndexLength/Canedo/Canedo/FlavioCanedo/FlavioCanedo
        [HttpGet]
        [Route("Canedo/IndexLength"),
            Route("Canedo/IndexLength/{minLength:minlength(4)}/{maxLength:maxlength(6)}/{length:length(12)}/{range:length(8,16)}")]
        public IActionResult IndexLength(string minLength, string maxLength, string length, string range)
        {
            return
                Json("{" +
                string.Format(
                    "'minLength':{0}, 'maxLength':{1}, 'length':{2}, 'range':{3}",
                    minLength, maxLength, length, range) + "}");
        }

        //Sample: {server]/Canedo/IndexLengthNumber/18/90/90
        [HttpGet]
        [Route("Canedo/IndexLengthNumber"),
            Route("Canedo/IndexLengthNumber/{min:min(18)}/{max:max(120)}/{range:range(18,120)}")]
        public IActionResult IndexLengthNumber(int min, int max, int range)
        {
            return Json("{" + string.Format("'min':{0}, 'max':{1}, 'range':{2}", min, max, range) + "}");
        }

        //Sample: {server}/Canedo/IndexCEP/17-055-100
        [HttpGet]
        [Route("Canedo/IndexCEP"),
            Route("Canedo/IndexCEP/{cep:regex(^\\d{{2}}-\\d{{3}}-\\d{{3}}$)}")]
        public IActionResult IndexCEP(string cep)
        {
            return Json("{" + string.Format("'cep':{0}", cep) + "}");
        }
    }
}