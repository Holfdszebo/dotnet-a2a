using System.Net.ServerSentEvents;
using System.Text.Json;

namespace A2A.V0_3;

/// <summary>
/// Extension methods for the <see cref="A2AClient"/> class making its API more
/// convenient for certain use-cases.
/// </summary>
public static class A2AClientExtensions
{
    /// <summary>
    /// Sends a message to the agent using a convenience overload that accepts an <see cref="AgentMessage"/>.
    /// </summary>
    /// <param name="client">The A2A client.</param>
    /// <param name="message">The message to send.</param>
    /// <param name="configuration">Optional message send configuration.</param>
    /// <param name="metadata">Optional metadata to include with the request.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>The agent's response containing a task or message.</returns>
    public static Task<A2AResponse> SendMessageAsync(
        this A2AClient client,
        AgentMessage message,
        MessageSendConfiguration? configuration = null,
        Dictionary<string, JsonElement>? metadata = null,
        CancellationToken cancellationToken = default)
    {
        if (client is null)
        {
            throw new ArgumentNullException(nameof(client));
        }

        return client.SendMessageAsync(
            new MessageSendParams
            {
                Message = message,
                Configuration = configuration,
                Metadata = metadata
            },
            cancellationToken);
    }

    /// <summary>
    /// Cancels a task using a convenience overload that accepts the task ID directly.
    /// </summary>
    /// <param name="client">The A2A client.</param>
    /// <param name="taskId">The ID of the task to cancel.</param>
    /// <param name="metadata">Optional metadata to include with the request.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>The updated task with canceled status.</returns>
    public static Task<AgentTask> CancelTaskAsync(
        this A2AClient client,
        string taskId,
        Dictionary<string, JsonElement>? metadata = null,
        CancellationToken cancellationToken = default)
    {
        if (client is null)
        {
            throw new ArgumentNullException(nameof(client));
        }

        return client.CancelTaskAsync(
            new TaskIdParams
            {
                Id = taskId,
                Metadata = metadata
            },
            cancellationToken);
    }

    /// <summary>
    /// Sets push notification configuration using a convenience overload that accepts individual values.
    /// </summary>
    /// <param name="client">The A2A client.</param>
    /// <param name="taskId">The ID of the task to configure.</param>
    /// <param name="url">The callback URL for push notifications.</param>
    /// <param name="configId">An optional push notification configuration ID.</param>
    /// <param name="token">An optional bearer token associated with the configuration.</param>
    /// <param name="authentication">Optional authentication information for the notification endpoint.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>The configured push notification settings with confirmation.</returns>
    public static Task<TaskPushNotificationConfig> SetPushNotificationAsync(
        this A2AClient client,
        string taskId,
        string url,
        string? configId = null,
        string? token = null,
        PushNotificationAuthenticationInfo? authentication = null,
        CancellationToken cancellationToken = default)
    {
        if (client is null)
        {
            throw new ArgumentNullException(nameof(client));
        }

        return client.SetPushNotificationAsync(
            new TaskPushNotificationConfig
            {
                TaskId = taskId,
                PushNotificationConfig = new PushNotificationConfig
                {
                    Id = configId,
                    Url = url,
                    Token = token,
                    Authentication = authentication
                }
            },
            cancellationToken);
    }

    /// <summary>
    /// Gets push notification configuration using a convenience overload that accepts task and config IDs directly.
    /// </summary>
    /// <param name="client">The A2A client.</param>
    /// <param name="taskId">The ID of the task whose configuration should be retrieved.</param>
    /// <param name="configId">The ID of the push notification configuration to retrieve.</param>
    /// <param name="metadata">Optional metadata to include with the request.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>The push notification configuration for the specified task.</returns>
    public static Task<TaskPushNotificationConfig> GetPushNotificationAsync(
        this A2AClient client,
        string taskId,
        string configId,
        Dictionary<string, JsonElement>? metadata = null,
        CancellationToken cancellationToken = default)
    {
        if (client is null)
        {
            throw new ArgumentNullException(nameof(client));
        }

        return client.GetPushNotificationAsync(
            new GetTaskPushNotificationConfigParams
            {
                Id = taskId,
                PushNotificationConfigId = configId,
                Metadata = metadata
            },
            cancellationToken);
    }

    /// <summary>
    /// Sends a streaming message using a convenience overload that accepts an <see cref="AgentMessage"/>.
    /// </summary>
    /// <param name="client">The A2A client.</param>
    /// <param name="message">The message to send.</param>
    /// <param name="configuration">Optional message send configuration.</param>
    /// <param name="metadata">Optional metadata to include with the request.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>An async enumerable of server-sent events containing task, message, or task update events.</returns>
    public static IAsyncEnumerable<SseItem<A2AEvent>> SendMessageStreamingAsync(
        this A2AClient client,
        AgentMessage message,
        MessageSendConfiguration? configuration = null,
        Dictionary<string, JsonElement>? metadata = null,
        CancellationToken cancellationToken = default)

    {
        if (client is null)
        {
            throw new ArgumentNullException(nameof(client));
        }

        return client.SendMessageStreamingAsync(
            new MessageSendParams
            {
                Message = message,
                Configuration = configuration,
                Metadata = metadata
            },
            cancellationToken);
    }
}
