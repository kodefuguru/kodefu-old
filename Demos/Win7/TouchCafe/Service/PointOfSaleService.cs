namespace TouchCafe.Service
{
    using TouchCafe.Models;

    public class PointOfSaleService
    {
        public void SubmitOrder(OrderModel order)
        {
            // Submit order to kitchen
        }
        public void ReportLocation(double latitude, double longitude)
        {
            // Submit location and station id to service
        }
        public void LocationMalfunction()
        {
            // Submit id of station which has a malfunctioning location sensor to the service
        }
    }
}
