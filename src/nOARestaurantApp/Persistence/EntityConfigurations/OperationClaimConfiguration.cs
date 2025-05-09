using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.Restaurants.Constants;
using Application.Features.RestaurantTables.Constants;
using Application.Features.Employees.Constants;
using Application.Features.Menus.Constants;
using Application.Features.Categories.Constants;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion

        
        #region Restaurants
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = RestaurantsOperationClaims.Admin },
                new() { Id = ++lastId, Name = RestaurantsOperationClaims.Read },
                new() { Id = ++lastId, Name = RestaurantsOperationClaims.Write },
                new() { Id = ++lastId, Name = RestaurantsOperationClaims.Create },
                new() { Id = ++lastId, Name = RestaurantsOperationClaims.Update },
                new() { Id = ++lastId, Name = RestaurantsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Restaurants
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = RestaurantsOperationClaims.Admin },
                new() { Id = ++lastId, Name = RestaurantsOperationClaims.Read },
                new() { Id = ++lastId, Name = RestaurantsOperationClaims.Write },
                new() { Id = ++lastId, Name = RestaurantsOperationClaims.Create },
                new() { Id = ++lastId, Name = RestaurantsOperationClaims.Update },
                new() { Id = ++lastId, Name = RestaurantsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region RestaurantTables
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = RestaurantTablesOperationClaims.Admin },
                new() { Id = ++lastId, Name = RestaurantTablesOperationClaims.Read },
                new() { Id = ++lastId, Name = RestaurantTablesOperationClaims.Write },
                new() { Id = ++lastId, Name = RestaurantTablesOperationClaims.Create },
                new() { Id = ++lastId, Name = RestaurantTablesOperationClaims.Update },
                new() { Id = ++lastId, Name = RestaurantTablesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Employees
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = EmployeesOperationClaims.Admin },
                new() { Id = ++lastId, Name = EmployeesOperationClaims.Read },
                new() { Id = ++lastId, Name = EmployeesOperationClaims.Write },
                new() { Id = ++lastId, Name = EmployeesOperationClaims.Create },
                new() { Id = ++lastId, Name = EmployeesOperationClaims.Update },
                new() { Id = ++lastId, Name = EmployeesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Employees
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = EmployeesOperationClaims.Admin },
                new() { Id = ++lastId, Name = EmployeesOperationClaims.Read },
                new() { Id = ++lastId, Name = EmployeesOperationClaims.Write },
                new() { Id = ++lastId, Name = EmployeesOperationClaims.Create },
                new() { Id = ++lastId, Name = EmployeesOperationClaims.Update },
                new() { Id = ++lastId, Name = EmployeesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Menus
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MenusOperationClaims.Admin },
                new() { Id = ++lastId, Name = MenusOperationClaims.Read },
                new() { Id = ++lastId, Name = MenusOperationClaims.Write },
                new() { Id = ++lastId, Name = MenusOperationClaims.Create },
                new() { Id = ++lastId, Name = MenusOperationClaims.Update },
                new() { Id = ++lastId, Name = MenusOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Menus
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MenusOperationClaims.Admin },
                new() { Id = ++lastId, Name = MenusOperationClaims.Read },
                new() { Id = ++lastId, Name = MenusOperationClaims.Write },
                new() { Id = ++lastId, Name = MenusOperationClaims.Create },
                new() { Id = ++lastId, Name = MenusOperationClaims.Update },
                new() { Id = ++lastId, Name = MenusOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Categories
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Read },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Write },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Create },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Update },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Menus
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MenusOperationClaims.Admin },
                new() { Id = ++lastId, Name = MenusOperationClaims.Read },
                new() { Id = ++lastId, Name = MenusOperationClaims.Write },
                new() { Id = ++lastId, Name = MenusOperationClaims.Create },
                new() { Id = ++lastId, Name = MenusOperationClaims.Update },
                new() { Id = ++lastId, Name = MenusOperationClaims.Delete },
            ]
        );
        #endregion
        
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
