using MediatR;

namespace OfferZen.Application.Events.CategoryEvents;

public record CategoryCreatedEvent(int CategoryId): INotification;
