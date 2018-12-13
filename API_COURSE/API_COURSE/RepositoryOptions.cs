namespace API_COURSE
{
    public static class RepositoryOptions
    {
        public static string DefaultConnectionString
        {
            get
            {
                return @"Data Source=(localdb)\ProjectsV13;Initial Catalog=BaseCourse;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            }

        }
    }
}