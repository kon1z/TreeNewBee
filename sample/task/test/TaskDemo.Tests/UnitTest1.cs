using System.Diagnostics;
using Shouldly;
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

namespace TaskDemo.Tests
{
	public class UnitTest1
	{
		[Fact]
		public async Task Should_ThrowException()
		{
			await Should.ThrowAsync<NotImplementedException>(async () =>
			{
				await ThrowExceptionAsync();
			});
		}

		[Fact]
		public async Task Should_Not_ThrowException()
		{
			await Should.NotThrowAsync(async () =>
			{
				ThrowExceptionAsync();
			});
		}

		[Fact]
		public async Task Should_Not_ThrowException_WithConfigureAwait()
		{
			await Should.NotThrowAsync(async () =>
			{
				ThrowExceptionAsync().ConfigureAwait(false);
			});
		}

		[Fact]
		public async Task Should_ThrowException_WithConfigureAwait()
		{
			await Should.NotThrowAsync(async () =>
			{
				ThrowExceptionAsync().ConfigureAwait(false).GetAwaiter();
			});
		}

		[Fact]
		public async Task CompareSpeedAsync()
		{
			var sw = Stopwatch.StartNew();
			await DelayAsync();
			await DelayAsync();
			sw.Stop();
			var asyncTime = sw.Elapsed;

			sw.Reset();
			sw.Start();
			var syncTim = Stopwatch.StartNew();
			DelayAsync();
			DelayAsync();
			sw.Stop();
			var syncTime = sw.Elapsed;

			sw.Reset();
			sw.Start();
			var task1 = DelayAsync();
			var task2 = DelayAsync();
			Task.WhenAll(task1, task2);
			sw.Stop();
			var waitAllTime = sw.Elapsed;
		}

		private Task ThrowExceptionAsync()
		{
			return Task.FromException(new NotImplementedException());
		}

		private Task DelayAsync()
		{
			Debug.Print(Thread.CurrentThread.Name);
			return Task.Delay(2000);
		}
	}
}