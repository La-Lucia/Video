using Plugin.Media;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace GrabarVideo
{
    public partial class MainPage : ContentPage
    {



        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try {

                var opciones = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
                {
                    Directory = "Videos",
                    Name ="VID_" + DateTime.Now.ToString() + ".mp4",
                    SaveToAlbum = true
                });


                if (opciones == null)
                {
                    await DisplayAlert("Atencion", "Archivo Vacio", "Aceptar");
                    return;
                }else
                {
                    var path = opciones.Path;
                    await DisplayAlert("Archivo guardado", "El video se ha guardado en la ruta:  " + path, "Aceptar");
                }

                




            } catch (Exception ex) {

                await DisplayAlert("Error", "Error" + ex, "Aceptar");
            
            }


    }

        private void VideoPlayer_PlayCompletion(object sender, EventArgs e)
        {

        }
    }
}
