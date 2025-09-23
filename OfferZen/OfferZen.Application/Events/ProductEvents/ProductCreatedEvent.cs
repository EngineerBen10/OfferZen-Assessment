using MediatR;

namespace OfferZen.Application.Events;

public record ProductCreatedEvent(int ProductId): INotification;