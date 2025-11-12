namespace AppointmentHubMVC.Models
{
    public class Appointments
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateOnly? EndDate { get; set;}

        public int Status { get; set; }
    }
}
