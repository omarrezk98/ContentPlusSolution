import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';
import { PermanentService } from '../utils/permanent.service';

@Pipe({
  name: 'dateDifference',
})
export class DateDifferencePipe implements PipeTransform {
  constructor(
    private datePipe: DatePipe,
    private permanent: PermanentService
  ) {}

  transform(value: string | Date): string | any {
    if (!value) return '';
    const date = this.convertUTCtoLocal(value);
    const now = new Date();
    const diff = Math.abs(now.getTime() - date.getTime());

    const seconds = Math.floor(diff / 1000);
    if (seconds < 60) {
      const s = this.permanent.activeLang?.code == 'ar' ? 'ثانية' : 's';
      return seconds + ' ' + s;
    }

    const minutes = Math.floor(seconds / 60);
    if (minutes < 60) {
      const m = this.permanent.activeLang?.code == 'ar' ? 'دقيقة' : 'm';
      return minutes + ' ' + m;
    }

    const hours = Math.floor(minutes / 60);
    if (hours < 24) {
      const h = this.permanent.activeLang?.code == 'ar' ? 'ساعة' : 'h';
      return hours + ' ' + h;
    }

    const days = Math.floor(hours / 24);
    if (days < 3) {
      const d = this.permanent.activeLang?.code == 'ar' ? 'يوم' : 'd';
      return days + ' ' + d;
    }

    return this.datePipe.transform(date, 'EEEE d MMM yyyy', undefined, this.permanent.activeLang.dateFormat);
  }

  convertUTCtoLocal(utcDate: string | Date): Date {
    if (typeof utcDate === 'string') {
      utcDate = new Date(utcDate); // Create a Date object from the UTC datetime string
    } else if (!(utcDate instanceof Date)) {
      return new Date(); // Return current date if input is invalid
    }
    const utcTime = utcDate.getTime(); // Get the UTC timestamp
    const timezoneOffset = utcDate.getTimezoneOffset(); // Get the timezone offset in minutes
    const localTime = utcTime - timezoneOffset * 60000; // Adjust the UTC time to local time
    const localDate = new Date(localTime);
    return localDate;
  }
}
