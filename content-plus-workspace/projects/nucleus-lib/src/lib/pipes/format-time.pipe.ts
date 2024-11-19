import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'formatTime' })
export class FormatTimePipe implements PipeTransform {
  transform(time: any, activeLang): string {
    if (!time) {
      return '';
    } else {
      const am = activeLang.code == 'en' ? ' AM' : ' ص';
      const pm = activeLang.code == 'en' ? ' PM' : ' م';

      time = time.toString().match(/^([01]\d|2[0-3])(:)([0-5]\d)(:[0-5]\d)?$/) || [time];
      if (time.length > 1) {
        time = time.slice(1);
        time[5] = +time[0] < 12 ? am : pm;
        time[0] = +time[0] % 12 || 12;
      }
      return time.join('');
    }
  }
}
