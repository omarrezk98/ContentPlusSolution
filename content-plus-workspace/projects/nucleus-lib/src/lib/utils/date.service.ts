import { Injectable } from '@angular/core';

@Injectable()
export class DateService {
  calculateBirthDate(y, m, d) {
    if (!(y <= 0 && m <= 0 && d <= 0)) {
      let year = y <= 0 ? new Date().getFullYear() : new Date().getFullYear() - y;
      let month = m <= 0 ? new Date().getMonth() : new Date().getMonth() - m;
      let day = d <= 0 ? new Date().getDate() : new Date().getDate() - d;
      if (day < 0) {
        day = 30 + day;
        month = month - 1;
      }
      if (month < 0) {
        month = 12 + month;
        year = year - 1;
      }
      return year + '/' + (month + 1) + '/' + day;
    }
  }

  calculateAge(dateOfBirth) {
    if (dateOfBirth != null && dateOfBirth != 'Invalid Date') {
      let year = new Date().getFullYear() - dateOfBirth.getFullYear();
      let month = new Date().getMonth() - dateOfBirth.getMonth();
      let day = new Date().getDate() - dateOfBirth.getDate();
      if (day < 0) {
        day = 30 + day;
        month = month - 1;
      }
      if (month < 0) {
        month = 12 + month;
        year = year - 1;
      }
      return { y: year, m: month, d: day };
    }
  }

  firstDayOfMonth() {
    const today = new Date();
    return new Date(today.getFullYear(), today.getMonth(), 1);
  }

  lastDayOfMonth() {
    const today = new Date();
    return new Date(today.getFullYear(), today.getMonth() + 1, 0);
  }

  getDaysInMonth(month, year) {
    var date = new Date(year, month, 1);
    var days: any = [];
    while (date.getMonth() === month) {
      days.push(new Date(date));
      date.setDate(date.getDate() + 1);
    }
    return days;
  }

  formatDateTime(date: Date) {
    if (date == null || typeof date === 'string') return date;
    const year = String(date.getFullYear()).length === 1 ? '0' + date.getFullYear() : date.getFullYear();
    const month = String(date.getMonth() + 1).length === 1 ? '0' + (date.getMonth() + 1) : date.getMonth() + 1;
    const day = String(date.getDate()).length === 1 ? '0' + date.getDate() : date.getDate();
    const hour = String(date.getHours()).length === 1 ? '0' + date.getHours() : date.getHours();
    const min = String(date.getMinutes()).length === 1 ? '0' + date.getMinutes() : date.getMinutes();
    return year + '-' + month + '-' + day + 'T' + hour + ':' + min + ':00';
  }

  formatDate(date: Date) {
    if (date == null || typeof date === 'string') return date;
    const year = String(date.getFullYear()).length === 1 ? '0' + date.getFullYear() : date.getFullYear();
    const month = String(date.getMonth() + 1).length === 1 ? '0' + (date.getMonth() + 1) : date.getMonth() + 1;
    const day = String(date.getDate()).length === 1 ? '0' + date.getDate() : date.getDate();
    return year + '-' + month + '-' + day;
  }

  formatTime(date: Date) {
    if (date == null || typeof date === 'string') return date;
    const hour = String(date.getHours()).length === 1 ? '0' + date.getHours() : date.getHours();
    const min = String(date.getMinutes()).length === 1 ? '0' + date.getMinutes() : date.getMinutes();
    return hour + ':' + min;
  }

  addMinutesToTime(timeString, minutesToAdd) {
    let time = new Date('1970-01-01T' + timeString + ':00');
    time.setMinutes(time.getMinutes() + minutesToAdd);
    let hours = time.getHours().toString().padStart(2, '0');
    let minutes = time.getMinutes().toString().padStart(2, '0');
    return `${hours}:${minutes}`;
  }

  calculateDifferenceByDays(startDate: Date, endDate: Date): number {
    if (startDate == null || typeof startDate === 'string') startDate = new Date(startDate);
    const utcStart = Date.UTC(startDate.getFullYear(), startDate.getMonth(), startDate.getDate());
    const utcEnd = Date.UTC(endDate.getFullYear(), endDate.getMonth(), endDate.getDate());
    const differenceInMillis = utcEnd - utcStart;
    // Convert milliseconds to days (1 day = 24 hours * 60 minutes * 60 seconds * 1000 milliseconds)
    const differenceInDays = differenceInMillis / (1000 * 60 * 60 * 24);
    return differenceInDays;
  }

}
