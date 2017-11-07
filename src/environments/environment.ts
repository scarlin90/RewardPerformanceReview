// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

export const environment = {
  production: false,

  apiRootUrl: 'http://performancereviewwebrest20171107124230.azurewebsites.net/api/',
  authenticateUrl: 'authenticate/',
  employeesUrl: 'employees/',
  employeesReviewsUrl: 'employeereviews/'
};
