using System;
using System.ComponentModel.DataAnnotations;

namespace Activities.Models
{
    public class NewEventViewModel : BaseEntity
    {
        public class MyDateAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                DateTime d = Convert.ToDateTime(value);
                return d > DateTime.Now;
            }
        }

        [Required(ErrorMessage = "Event Title is required.")]
        [StringLength(255, ErrorMessage = "Title must be betwen 5 and 255 characters", MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        [MyDate(ErrorMessage="Date must be in the future")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Event Time is required.")]
        public DateTime EventTime { get; set; }

        [Required(ErrorMessage = "Event Duration is required.")]
        [Range(1, 60, ErrorMessage = "Duration must be between 1 and 60")]
        public int Duration { get; set; }

        public String DurationType { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000, ErrorMessage = "Description must be betwen 5 and 1000 characters", MinimumLength = 5)]
        public string Description { get; set; }
    }
}