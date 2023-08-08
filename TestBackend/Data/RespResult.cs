namespace TestBackend.Data
{
    public class RespResult
    {
        public Guid user_id { get; set; }
        public long count_sign_in { get; set; }

        public RespResult(Guid user_id, long count_sign_in)
        {
            this.user_id = user_id;
            this.count_sign_in = count_sign_in;
        }
    }
}
