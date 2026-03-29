// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Security Hotspot", "S4834:Controlling permissions is security-sensitive", Justification = "Needed for Microsoft.AspNetCore.Authorization.IAuthorizationService", Scope = "type", Target = "~T:GtMotive.Estimate.Microservice.Domain.Interfaces.IAuthorizationService")]
[assembly: SuppressMessage("Major Code Smell", "S2326:Unused type parameters should be removed", Justification = "T is necessary for dependency injection.", Scope = "type", Target = "~T:GtMotive.Estimate.Microservice.Domain.Interfaces.IAppLogger`1")]
[assembly: SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1010:Opening square brackets should be spaced correctly", Justification = "Reviewed.", Scope = "member", Target = "~P:GtMotive.Estimate.Microservice.Domain.Events.DomainEvent`1.Actions")]
[assembly: SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "It is a operator symbnol", Scope = "member", Target = "~M:GtMotive.Estimate.Microservice.Domain.ValueObjects.Money.op_Addition(GtMotive.Estimate.Microservice.Domain.ValueObjects.Money,GtMotive.Estimate.Microservice.Domain.ValueObjects.Money)~GtMotive.Estimate.Microservice.Domain.ValueObjects.Money")]
[assembly: SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1010:Opening square brackets should be spaced correctly", Justification = "Initialization with [] is accepted", Scope = "member", Target = "~P:GtMotive.Estimate.Microservice.Domain.Entities.Vehicle.Bookings")]
[assembly: SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1010:Opening square brackets should be spaced correctly", Justification = "Initialization with [] is accepted", Scope = "member", Target = "~P:GtMotive.Estimate.Microservice.Domain.Entities.User.Bookings")]
[assembly: SuppressMessage("Style", "IDE0046:Convert to conditional expression", Justification = "It is more clear using if", Scope = "member", Target = "~M:GtMotive.Estimate.Microservice.Domain.ValueObjects.DateRange.IsDateRangeValid(System.DateOnly,System.DateOnly)~System.Boolean")]
