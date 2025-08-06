# Chain of Responsibility with Dependency Injection
Реализация паттерна **Chain of Responsibility**, позволяющая собирать цепочку обработчиков через **Microsoft.Extensions.DependencyInjection**.

## Пример использования
В качестве примера добавлены `TrimHandler` и `UpperCaseHandler`. 
Регистрация цепочки в DI: `services.AddChainOfResponsibility()`

## Использование

```plaintext
var handler = serviceProvider.GetRequiredService<IChainHandler<string>>();
await handler.HandleAsync("Hello World!   ", CancellationToken.None);
```
