using kuna.Models;
using kuna.View;
using kuna.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace kuna.ViewModels
{
    public class PostearViewModel : ViewModelBase
    {
        public string nombre;
        public string especie;
        public int edad;
        public string tamanio;
        public string raza;
        public string imagen;
        public string color;
        public string caracteristicas;

        public string Nombre
        {
            get { return nombre; }

            set
            {
                nombre = value;
                OnPropertyChanged(nameof(nombre));//Para actualizar la vista 
            }

        }

        public string Especie
        {
            get
            {
                return especie;
            }

            set
            {
                especie = value;
                OnPropertyChanged(nameof(especie));//Para actualizar la vista 
            }
        }

        public int Edad
        {
            get
            {
                return edad;
            }

            set
            {
                edad = value;
                OnPropertyChanged(nameof(edad));//Para actualizar la vista 
            }
        }


        public string Tamanio
        {
            get
            {
                return tamanio;
            }

            set
            {
                tamanio = value;
                OnPropertyChanged(nameof(tamanio));//Para actualizar la vista 
            }
        }

        public string Raza
        {
            get
            {
                return raza;
            }

            set
            {
                raza = value;
                OnPropertyChanged(nameof(raza));//Para actualizar la vista 
            }
        }

        public string Imagen
        {
            get
            {
                return imagen;
            }

            set
            {
                imagen = value;
                OnPropertyChanged(nameof(imagen));//Para actualizar la vista 
            }
        }

        public string Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
                OnPropertyChanged(nameof(color));//Para actualizar la vista 
            }
        }

        public string Caracteristicas
        {
            get
            {
                return caracteristicas;
            }

            set
            {
                caracteristicas = value;
                OnPropertyChanged(nameof(caracteristicas));//Para actualizar la vista 
            }
        }

        public void Postear()
        {
            // Verifica si los campos obligatorios están llenos
            if (string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Especie) || string.IsNullOrEmpty(Color) || string.IsNullOrEmpty(Caracteristicas)
                || string.IsNullOrEmpty(Imagen) || string.IsNullOrEmpty(Tamanio) || string.IsNullOrEmpty(Raza))
            {
                MessageBox.Show("Por favor, completa todos los campos obligatorios.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // Opcional: Limpia los campos después de realizar el post
                ServicePost.Post(nombre, especie, edad, imagen, tamanio, raza, color, caracteristicas);

            }
        }

        public void Limpiar()
        {
            Nombre = "";
            Especie = "";
            Edad = 0;
            Tamanio = "";
            Raza = "";
            Imagen = "";
            Color = "";
            Caracteristicas = "";
        }

    }
}
