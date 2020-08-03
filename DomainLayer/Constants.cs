using System;

namespace DomainLayer
{
    public static class Constants
    {
   public static string PrimaryKey = Environment.GetEnvironmentVariable("PrimaryKey", EnvironmentVariableTarget.Process);
        public static string Uri = Environment.GetEnvironmentVariable("URI", EnvironmentVariableTarget.Process);
    }
}
