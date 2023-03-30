namespace testBlazor.Data.security
{
    using System.Security.Claims;
    using System.Security.Principal;
    using System.Threading.Tasks;
    using Blazored.SessionStorage;
    using Microsoft.AspNetCore.Components.Authorization;

    /// <summary>
    /// Кастомный поставщик статуса идентификации.
    /// </summary>
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        /// <summary>
        /// Сессия.
        /// </summary>
        private ISessionStorageService _sessionStorageService;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="sessionStorageService">Сессия.</param>
        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorageService) 
        {
            _sessionStorageService = sessionStorageService;
        }

        /// <summary>
        /// Асинхронно возвращяет статус идентификации.
        /// </summary>
        /// <returns>Статус идетификации.</returns>
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var userEmailAddress = await _sessionStorageService.GetItemAsync<string>("email");

            ClaimsIdentity identity;

            if (userEmailAddress != null) 
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userEmailAddress),
                }, "Custom Authentication");
            }
            else
            {
                identity = new ClaimsIdentity();
            }
            
            var user = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(user));
        }

        /// <summary>
        /// Устанавливает статус идетификации для пользователя.
        /// </summary>
        /// <param name="userEmailAddress">Адрес электронной почты.</param>
        public void userAuthorized(string userEmailAddress)
        {
            var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userEmailAddress),
                }, "Custom Authentication");

            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));

        }

        /// <summary>
        /// Очишает статас идетификации.
        /// </summary>
        public void userNotAuthorized()
        {
            _sessionStorageService.RemoveItemAsync("email");

            var identity = new ClaimsIdentity();

            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

    }
}
