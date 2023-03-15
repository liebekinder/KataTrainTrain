using Microsoft.AspNetCore.Mvc;
using TrainTrain.Bookings.ApplicationServices.PrimaryPorts;
using TrainTrain.Bookings.Web.Mappers;
using TrainTrain.Bookings.Web.Payloads;

namespace TrainTrain.Bookings.Web.Controllers;

public sealed class BookingController : ControllerBase
{
    private readonly IBookingApplicationService _bookingApplicationService;

    public BookingController(IBookingApplicationService bookingApplicationService)
    {
        _bookingApplicationService = bookingApplicationService;
    }

    [HttpPost]
    public async Task<IActionResult> BookAsync(BookingPayload payload)
    {
        var bookingCandidate = BookingMapper.ToCandidate(payload);

        await _bookingApplicationService.BookAsync(bookingCandidate);

        return Ok();
    }
}

