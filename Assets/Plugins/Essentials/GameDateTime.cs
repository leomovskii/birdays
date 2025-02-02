using System;
using UnityEngine;

namespace Essentials {
	public class GameDateTime {

		[Serializable]
		private struct GameDateTimeData {
			public int Day, Month, Year;

			public void Normalize() {
				if (Day > DaysInMonth) {
					int monthsDelta = Day / DaysInMonth;
					Month += monthsDelta;
					Day -= monthsDelta * DaysInMonth;
				}

				if (Month > MonthsInYear) {
					int yearsDelta = Month / MonthsInYear;
					Year += yearsDelta;
					Month -= yearsDelta * MonthsInYear;
				}

				if (Day == 0)
					Day = 1;
				if (Month == 0)
					Month = 1;
				if (Year == 0)
					Year = 1;
			}
		}

		public readonly static int DaysInMonth = 28;
		public readonly static int MonthsInYear = 12;
		public readonly static int DaysInYear = 336; // CACHE TO AVOID EXCESS CALCULATIONS!!!

		private GameDateTimeData _data = new GameDateTimeData();

		public int TotalDays => _data.Day + (_data.Month + (_data.Year * MonthsInYear)) * DaysInMonth;
		public int Day => _data.Day;
		public int Month => _data.Month;
		public int Year => _data.Year;

		public GameDateTime() {
			_data.Day = 1;
			_data.Month = 1;
			_data.Year = 1;
		}

		public GameDateTime(int totalDays) {
			if (totalDays < 0) {
				throw new ArgumentException("Total days can't be less that 0.");
			} else {
				_data.Day = totalDays;
				_data.Normalize();
			}
		}

		public GameDateTime(int day, int month, int year) {
			if (day < 1 || day > DaysInMonth) {
				throw new ArgumentException($"Day can't be less than 1 and greater than {DaysInMonth}.");
			} else if (month < 1 || month > MonthsInYear) {
				throw new ArgumentException($"Month can't be less than 1 and greater than {MonthsInYear}.");
			} else if (year < 1) {
				throw new ArgumentException("Year can't be less than 1.");
			} else {
				_data.Day = day;
				_data.Month = month;
				_data.Year = year;
				_data.Normalize();
			}
		}

		public static GameDateTime FromJson(string jsonString) {
			if (string.IsNullOrEmpty(jsonString))
				return new GameDateTime();

			var data = JsonUtility.FromJson<GameDateTimeData>(jsonString);
			return new GameDateTime(data.Day, data.Month, data.Year);
		}

		public override string ToString() {
			return JsonUtility.ToJson(_data);
		}

		public static int Compare(GameDateTime t1, GameDateTime t2) {
			return t1.TotalDays.CompareTo(t2.TotalDays);
		}

		public static int Distance(GameDateTime t1, GameDateTime t2) {
			return Mathf.Abs(t1.TotalDays - t2.TotalDays);
		}

		public bool IsLastDayOfMonth() {
			return _data.Day + 1 == DaysInMonth;
		}

		public bool IsLastMonthOfYear() {
			return _data.Month + 1 == MonthsInYear;
		}

		public bool IsLastDayOfYear() {
			return IsLastDayOfMonth() && IsLastMonthOfYear();
		}

		public void AddDays(int days) {
			if (days < 0) {
				throw new ArgumentException("Days can't be less than 0.");
			} else {
				_data.Day += days;
				_data.Normalize();
			}
		}

		public void AddMonths(int months) {
			if (months < 0) {
				throw new ArgumentException("Months can't be less than 0.");
			} else {
				_data.Month += months;
				_data.Normalize();
			}
		}

		public void AddYears(int years) {
			if (years < 0) {
				throw new ArgumentException("Years can't be less than 0.");
			} else {
				_data.Year += years;
			}
		}

		public static bool operator ==(GameDateTime t1, GameDateTime t2) {
			return t1.Equals(t2);
		}

		public static bool operator !=(GameDateTime t1, GameDateTime t2) {
			return !t1.Equals(t2);
		}

		public static bool operator <(GameDateTime t1, GameDateTime t2) {
			return t1.TotalDays < t2.TotalDays;
		}

		public static bool operator <=(GameDateTime t1, GameDateTime t2) {
			return t1.TotalDays <= t2.TotalDays;
		}

		public static bool operator >(GameDateTime t1, GameDateTime t2) {
			return t1.TotalDays > t2.TotalDays;
		}

		public static bool operator >=(GameDateTime t1, GameDateTime t2) {
			return t1.TotalDays >= t2.TotalDays;
		}

		public static GameDateTime operator +(GameDateTime t1, GameDateTime t2) {
			return new GameDateTime(t1.TotalDays + t2.TotalDays);
		}

		public override bool Equals(object obj) {
			return obj is GameDateTime other && TotalDays == other.TotalDays;
		}

		public override int GetHashCode() {
			return TotalDays.GetHashCode();
		}
	}
}