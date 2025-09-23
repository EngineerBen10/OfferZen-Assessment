using MediatR;

namespace OfferZen.Application.Events;

public record ProductDeletedEvent(int ProductId): INotification;