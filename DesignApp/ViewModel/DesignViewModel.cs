using DesignApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignApp.ViewModel
{
    public class DesignViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CardItem> Cards { get; }

        private CardItem _selectedCard;
        public CardItem SelectedCard
        {
            get => _selectedCard;
            set
            {
                if (_selectedCard != value)
                {
                    if (_selectedCard != null)
                        _selectedCard.IsSelected = false;

                    _selectedCard = value;

                    if (_selectedCard != null)
                        _selectedCard.IsSelected = true;

                    OnPropertyChanged(nameof(SelectedCard));
                }
            }
        }

        public DesignViewModel()
        {
            Cards = new ObservableCollection<CardItem>()
            {
                new CardItem { Id = "1" },
                new CardItem { Id = "2" },
                new CardItem { Id = "3" },
                new CardItem { Id = "4" },
                new CardItem { Id = "1" },
                new CardItem { Id = "2" },
                new CardItem { Id = "3" },
                new CardItem { Id = "4" },
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
