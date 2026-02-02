namespace SeleniumFramework.DatabaseOperations.Queries
{
    public static class UserQueries
    {
        public static string DeleteUserByEmail(string email)
        {
            return $@"
                DELETE FROM users
                WHERE Email = '{email}';
            ";
        }
    }
}