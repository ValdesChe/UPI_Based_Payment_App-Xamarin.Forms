using System;
using System.Threading.Tasks;
using UPIBasedPaymentApp.Services.Abstractions;

namespace UPIBasedPaymentApp.Services
{
    public class PreferencesService: IStorageService
    {
        public static string KeyFormat = "UPIPayement-AppPreferencesStorage:{0}";

        private readonly string _sharedName;
        public PreferencesService(string sharedName = null)
        {
            _sharedName = sharedName;
        }


        public Task<T> GetAsync<T>(string key, T defaultValue = default(T))
        {
            var formattedKey = string.Format(KeyFormat, key);
            if (!Xamarin.Essentials.Preferences.ContainsKey(formattedKey, _sharedName))
            {
                return Task.FromResult(defaultValue);
            }

            var objType = typeof(T);
            if (objType == typeof(string))
            {
                var val = Xamarin.Essentials.Preferences.Get(formattedKey, default(string), _sharedName);
                return Task.FromResult((T)(object)val);
            }
            else if (objType == typeof(bool) || objType == typeof(bool?))
            {
                var val = Xamarin.Essentials.Preferences.Get(formattedKey, true, _sharedName);
                return Task.FromResult(ChangeType<T>(val));
            }
            else if (objType == typeof(int) || objType == typeof(int?))
            {
                var val = Xamarin.Essentials.Preferences.Get(formattedKey, default(int), _sharedName);
                return Task.FromResult(ChangeType<T>(val));
            }
            else if (objType == typeof(long) || objType == typeof(long?))
            {
                var val = Xamarin.Essentials.Preferences.Get(formattedKey, default(long), _sharedName);
                return Task.FromResult(ChangeType<T>(val));
            }
            else if (objType == typeof(double) || objType == typeof(double?))
            {
                var val = Xamarin.Essentials.Preferences.Get(formattedKey, default(double), _sharedName);
                return Task.FromResult(ChangeType<T>(val));
            }
            else if (objType == typeof(DateTime) || objType == typeof(DateTime?))
            {
                var val = Xamarin.Essentials.Preferences.Get(formattedKey, default(DateTime), _sharedName);
                return Task.FromResult(ChangeType<T>(val));
            }
            return null;
        }


        public Task RemoveAsync(string key)
        {
            var formattedKey = string.Format(KeyFormat, key);
            if (Xamarin.Essentials.Preferences.ContainsKey(formattedKey, _sharedName))
            {
                Xamarin.Essentials.Preferences.Remove(formattedKey, _sharedName);
            }
            return Task.FromResult(0);
        }

        public Task SaveAsync<T>(string key, T obj)
        {
            if (obj == null)
            {
                return RemoveAsync(key);
            }

            var formattedKey = string.Format(KeyFormat, key);
            var objType = typeof(T);
            if (objType == typeof(string))
            {
                Xamarin.Essentials.Preferences.Set(formattedKey, obj as string, _sharedName);
            }
            else if (objType == typeof(bool) || objType == typeof(bool?))
            {
                Xamarin.Essentials.Preferences.Set(formattedKey, (obj as bool?).Value, _sharedName);
            }
            else if (objType == typeof(int) || objType == typeof(int?))
            {
                Xamarin.Essentials.Preferences.Set(formattedKey, (obj as int?).Value, _sharedName);
            }
            else if (objType == typeof(long) || objType == typeof(long?))
            {
                Xamarin.Essentials.Preferences.Set(formattedKey, (obj as long?).Value, _sharedName);
            }
            else if (objType == typeof(double) || objType == typeof(double?))
            {
                Xamarin.Essentials.Preferences.Set(formattedKey, (obj as double?).Value, _sharedName);
            }
            else if (objType == typeof(DateTime) || objType == typeof(DateTime?))
            {
                Xamarin.Essentials.Preferences.Set(formattedKey, (obj as DateTime?).Value, _sharedName);
            }

            return Task.FromResult(0);
        }


        private static T ChangeType<T>(object value)
        {
            var t = typeof(T);
            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return default(T);
                }
                t = Nullable.GetUnderlyingType(t);
            }
            return (T)Convert.ChangeType(value, t);
        }
    }
}
