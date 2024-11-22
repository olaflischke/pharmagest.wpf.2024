using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WpfCommunityToolkit.Infrastructure;

namespace WpfCommunityToolkit.ExtensionMethods;

public static class FileLoggerExtensions
{
    public static ILoggingBuilder AddFileLogger(this ILoggingBuilder builder, string filePath)
    {
        builder.Services.AddSingleton<ILoggerProvider, FileLoggerProvider>(provider => new FileLoggerProvider(filePath));
        return builder;
    }
}
