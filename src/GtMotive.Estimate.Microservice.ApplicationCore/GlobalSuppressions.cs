// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Naming", "CA1711:Identifiers should not have incorrect suffix", Justification = "The suffix EventHandler is relevant for clarity and cohesion", Scope = "type", Target = "~T:GtMotive.Estimate.Microservice.ApplicationCore.EventHandlers.VehicleAddedEventHandler")]
[assembly: SuppressMessage("Naming", "CA1711:Identifiers should not have incorrect suffix", Justification = "Suffix is correct for cohesion", Scope = "type", Target = "~T:GtMotive.Estimate.Microservice.ApplicationCore.EventHandlers.BookingCanceledEventHandler")]
[assembly: SuppressMessage("Naming", "CA1711:Identifiers should not have incorrect suffix", Justification = "Suffix is correct for cohesion", Scope = "type", Target = "~T:GtMotive.Estimate.Microservice.ApplicationCore.EventHandlers.BookingConfirmedEventHandler")]
[assembly: SuppressMessage("Naming", "CA1711:Identifiers should not have incorrect suffix", Justification = "Suffix is correct for cohesion", Scope = "type", Target = "~T:GtMotive.Estimate.Microservice.ApplicationCore.EventHandlers.BookingCreatedEventHandler")]
[assembly: SuppressMessage("Naming", "CA1711:Identifiers should not have incorrect suffix", Justification = "Suffix is correct for cohesion", Scope = "type", Target = "~T:GtMotive.Estimate.Microservice.ApplicationCore.EventHandlers.BookingFinishedEventHandler")]
[assembly: SuppressMessage("Major Code Smell", "S107:Methods should not have too many parameters", Justification = "It is neccessary send 9 parametres", Scope = "type", Target = "~T:GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.Cancel.BookingCanceledIntegrationEvent")]
[assembly: SuppressMessage("Major Code Smell", "S107:Methods should not have too many parameters", Justification = "It is neccessary send 9 parametres", Scope = "type", Target = "~T:GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.Finish.BookingFinishedIntegrationEvent")]
[assembly: SuppressMessage("Major Code Smell", "S107:Methods should not have too many parameters", Justification = "It is neccessary send 9 parametres", Scope = "type", Target = "~T:GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.MakeNew.BookingCreatedIntegrationEvent")]
