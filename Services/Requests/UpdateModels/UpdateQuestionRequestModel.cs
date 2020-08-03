namespace Services.Requests
{
    public class UpdateQuestionRequestModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Complexity { get; set; }
    }
}
