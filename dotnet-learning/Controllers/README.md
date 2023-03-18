# Controllers
A controller-based API (as opposed to a _Minimal API_) consists of one or more _controller classes_. A standard controller can be defined with:

```cs
[ApiController]
[Route("[controller]")]
public class RestuarantReviewController : ControllerBase
```
## ApiController Attribute
The `[ApiController]` attribute enables API-specific behaviours:
- Attribute routing requirement
- Automatic HTTP 400 responses
- Multipart/form-data request inference

among others. If you want to apply `[ApiController]` to multiple controllers, you can create your own custom controller base:

```cs
[ApiController]
public class ApiControllerBase : Controller Base {}
```
```cs
[Route("[controller]")]
public class RestuarantReviewController : ApiControllerBase
```

## Route
`[Route("[controller]")]` defines the route to access the endpoints. `[controller]` is replaced with the name of the controller class (minus the _controller_ word). So for our app our endpoint for this controller would be
```cs
http://localhost:5194/restaurantreview
```
Any further routes specified in individual endpoints, such as
```cs
[HttpGet("{id}")]
```
will be appended to this base controller route

## Endpoints
ASP.NET Core has the following _HTTP verb_ templates to create endpoints
- `[HttpGet]`
- `[HttpPost]`
- `[HttpPut]`
- `[HttpDelete]`
- `[HttpHead]`
- `[HttpPatch]`

For example a basic get endpoint could look like:
```cs
[HttpGet("ping")]
public String HelloWorld()
{
    return $"Hello World";
}
```
Visiting `http://localhost:5194/restaurantreview/ping` would then return `"Hello World"`.

## Return Types
Although we can return specific types in our controller, such as
```cs
public String HelloWorld()
```
we can also make use of `IActionResult`. This can be used when multiple `ActionResult` return types are possible (BadRequest, NotFoundResult, OkObjectResult etc...). An example would be:

```cs
[HttpGet()]
public IActionResult GetAllProducts()
{
    var products = _storeService.GetData();
    return Ok(products);
}
```
Not only does this allow us to return an HTTP action result, it also automatically serializes the OK data object into JSON, and allows the browser to more easily interpret the result.