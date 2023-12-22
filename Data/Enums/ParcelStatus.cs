namespace Data.Enums
{
    public enum ParcelStatus
    {
        RecievedBySender,
        InTransitToSortCenter,
        RecievedBySortCenter,
        InTransitToReciever,
        RecievedByRecipient,
        ReadyForGranting,
        Granted,
        ReturnToSender,
        Lost,
        Found,
        PackageDestroyed
    }
}
