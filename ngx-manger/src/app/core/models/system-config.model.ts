export class SystemConfigModel {
    constructor(
        public production: boolean = false,
        public serverUrl: string = '',
        public domain: string = ''
    ) { }
}