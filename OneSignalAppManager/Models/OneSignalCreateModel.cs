using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneSignalAppManager.Models
{
    public class OneSignalCreateModel
    {
        public string id { get; set; }
        //Required The name of your new app, as displayed on your apps list on the dashboard. This can be renamed later.
        public string name { get; set; }
        //iOS - Either sandbox or production
        public string apns_env { get; set; }
        //iOS - Your apple push notification p12 certificate file, converted to a string and Base64 encoded.
        public string apns_p12 { get; set; }
        //Required if adding p12 certificate iOS - Password for the apns_p12 file
        public string apns_p12_password { get; set; }
        //Android - Your Google Push Messaging Auth Key
        public string gcm_key { get; set; }
        //Android - Your Google Project number. Also know as Sender ID.
        public string android_gcm_sender_id { get; set; }
        //Chrome, Firefox - The URL to your website. This field is required if you wish to enable web push and specify other web push parameters.
        public string chrome_web_origin { get; set; }
        //Chrome - Your default notification icon. Should be 80x80 pixels.
        public string chrome_web_default_notification_icon { get; set; }
        //Chrome - A subdomain of your choice in order to support Chrome Web Push on non-HTTPS websites. This field must be set in order for the chrome_web_gcm_sender_id property to be processed.
        public string chrome_web_sub_domain { get; set; }
        //Not for web push. Your Google Push Messaging Auth Key if you use Chrome Apps / Extensions.
        public string chrome_key { get; set; }
        //Safari - Your apple push notification p12 certificate file for Safari Push Notifications, converted to a string and Base64 encoded.
        public string safari_apns_p12 { get; set; }
        //Safari - Password for safari_apns_p12 file
        public string safari_apns_p12_password { get; set; }
        //Safari - The URL to your website
        public string site_name { get; set; }
        //Safari - The hostname to your website including http(s)://
        public string safari_site_origin { get; set; }
        //Safari - A url for a 256x256 png notification icon. This is the only Safari icon URL you need to provide.
        public string safari_icon_256_256 { get; set; }
        //The Id of the Organization you would like to add this app to.
        public string organization_id { get; set; }
        //iOS - Notification data (additional data) values will be added to the root of the apns payload when sent to the device.
        //Ignore if you're not using any other plugins or not using OneSignal SDK methods to read the payload.
        public bool additional_data_is_root_payload { get; set; }

        public static OneSignalCreateModel parse(OneSignalModel oneSignalModel)
        {
            return new OneSignalCreateModel
            {
                id = oneSignalModel.id,
                name = oneSignalModel.name,
                apns_env = oneSignalModel.apns_env,
                apns_p12 = oneSignalModel.apns_certificates,
                //apns_p12_password = ,
                gcm_key = oneSignalModel.gcm_key,
                //android_gcm_sender_id = ,
                chrome_web_origin = oneSignalModel.chrome_web_origin,
                chrome_web_default_notification_icon = oneSignalModel.chrome_web_default_notification_icon,
                chrome_web_sub_domain = oneSignalModel.chrome_web_sub_domain,
                chrome_key = oneSignalModel.chrome_key,
                safari_apns_p12 = oneSignalModel.safari_apns_certificate,
                //safari_apns_p12_password = ,
                site_name = oneSignalModel.site_name,
                safari_site_origin = oneSignalModel.safari_site_origin,
                safari_icon_256_256 = oneSignalModel.safari_icon_256_256,
                //organization_id = ,
                additional_data_is_root_payload = oneSignalModel.additional_data_is_root_payload
            };
        }
    }
}
