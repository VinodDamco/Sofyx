using SofyxWeb.ApplicationCore.Exceptions;
using SofyxWeb.ApplicationCore.Entities;

namespace Ardalis.GuardClauses
{
    public static class BasketGuards
    {
        public static void NullBasket(this IGuardClause guardClause, int basketId, Customer customer)
        {
            if (customer == null)
                throw new BasketNotFoundException(basketId);
        }
    }
}