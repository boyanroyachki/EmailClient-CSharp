namespace EmailClient.Common
{
    public static class Methods
    {
        public static string GemEmailType(string email)
        {
            return email.Split('@')[1];
        }
    }
}
