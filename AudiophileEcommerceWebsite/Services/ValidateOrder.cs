namespace AudiophileEcommerceWebsite.Services;

public interface IValidateOrder
{
    Task<bool> IsValid(int orderId);
}

public class ValidateOrder : IValidateOrder
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUserService _userService;

    public ValidateOrder(IOrderRepository orderRepository,
        IUserService userService)
    {
        _orderRepository = orderRepository;
        _userService = userService;
    }

    public async Task<bool> IsValid(int orderId)
    {
        var currentUser = await _userService.GetCurrentUser();
        var order = _orderRepository.GetOrder(orderId);

        return currentUser.Id == order.User.Id;
    }
}