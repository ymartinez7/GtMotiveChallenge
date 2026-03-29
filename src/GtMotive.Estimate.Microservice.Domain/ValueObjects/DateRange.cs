using System;
using GtMotive.Estimate.Microservice.Domain.Exceptions;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// Date Range value object.
    /// </summary>
    public sealed record DateRange
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateRange"/> class.
        /// </summary>
        /// <param name="startDate">startDate.</param>
        /// <param name="endDate">endDate.</param>
        public DateRange(DateOnly startDate, DateOnly endDate)
        {
            if (IsDateRangeValid(startDate, endDate))
            {
                StartDate = startDate;
                EndDate = endDate;
            }
        }

        /// <summary>
        /// Gets StartDate.
        /// </summary>
        public DateOnly StartDate { get; init; }

        /// <summary>
        /// Gets EndDate.
        /// </summary>
        public DateOnly EndDate { get; init; }

        /// <summary>
        /// Gets LengthInDays.
        /// </summary>
        public int LengthInDays => EndDate.DayNumber - StartDate.DayNumber;

        private static bool IsDateRangeValid(DateOnly startDate, DateOnly endDate)
        {
            if (startDate > endDate)
            {
                throw new BookingDateRangeException("End date precedes start date");
            }

            if (startDate == endDate)
            {
                throw new BookingDateRangeException("Start date cannot be equal to end date.");
            }

            return true;
        }
    }
}
