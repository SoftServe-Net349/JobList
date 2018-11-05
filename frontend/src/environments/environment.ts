// This file can be replaced during build by using the `fileReplacements` array.
// `ng build ---prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
export const environment = {
  production: false,
  server_url: 'http://localhost:56681',
  client_url: 'http://localhost:4200',
  firebase: {
    apiKey: 'AIzaSyAG1-eRjUhpALauRp4MchwAcOGr8EPAC_4',
    authDomain: 'joblist-f3c1b.firebaseapp.com',
    databaseURL: 'https://joblist-f3c1b.firebaseio.com',
    projectId: 'joblist-f3c1b',
    storageBucket: 'joblist-f3c1b.appspot.com',
    messagingSenderId: '669284982796'
  }
};

/*
 * In development mode, to ignore zone related error stack frames such as
 * `zone.run`, `zoneDelegate.invokeTask` for easier debugging, you can
 * import the following file, but please comment it out in production mode
 * because it will have performance impact when throw error
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
