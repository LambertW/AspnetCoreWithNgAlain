import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID, APP_INITIALIZER, Injector } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClient, HTTP_INTERCEPTORS } from '@angular/common/http';

import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';
import { AppComponent } from './app.component';
import { RoutesModule } from './routes/routes.module';
import { LayoutModule } from './layout/layout.module';
import { StartupService } from './core/services/startup.service';
import { DefaultInterceptor } from '@core/net/default.interceptor';
import { AlainAuthModule, SimpleInterceptor } from '@delon/auth';

import { registerLocaleData } from '@angular/common';
import localeZhHans from '@angular/common/locales/zh-Hans';
registerLocaleData(localeZhHans);

export function StartupServiceFactory(startupService: StartupService): Function {
    return () => startupService.load();
}

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        SharedModule.forRoot(),
        CoreModule,
        LayoutModule,
        RoutesModule,
        // auth
        AlainAuthModule.forRoot({
            login_url: `/passport/login`
        })
    ],
    providers: [
        { provide: LOCALE_ID, useValue: 'zh-Hans' },
        // token interception
        { provide: HTTP_INTERCEPTORS, useClass: SimpleInterceptor, multi: true},
        // default innterception
        { provide: HTTP_INTERCEPTORS, useClass: DefaultInterceptor, multi: true},
        StartupService,
        {
            provide: APP_INITIALIZER,
            useFactory: StartupServiceFactory,
            deps: [StartupService],
            multi: true
        }
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
