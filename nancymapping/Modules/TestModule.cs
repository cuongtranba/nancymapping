using Nancy;

namespace nancymapping.Modules
{
    public class TestModule:NancyModule
    {
        public TestModule():base("/api/test")
        {
            Post["/"] = parameters =>
            {
                var model=this.bi
            }
        }

    }
}
