namespace API.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttribute : AuthorizeAttribute
    {
    }
}
