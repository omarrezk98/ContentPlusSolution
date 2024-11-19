import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'dayName' })
export class DayNamePipe implements PipeTransform {
  transform(year: any, month: any, day: any, lang): any {
    if (!year || !month || !day) {
      return;
    } else {
      var enDays = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
      var arDays = ['الأحد', 'الإثنين', 'الثلاثاء', 'الأربعاء', 'الخميس', 'الجمعة', 'السبت'];
      var d = new Date(Date.UTC(year, month, day));
      return lang == 'en' ? enDays[d.getDay()] : arDays[d.getDay()];
    }
  }
}
