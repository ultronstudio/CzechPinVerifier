using CzechPinVerifier.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CzechPinVerifier
{
    public partial class App : Form
    {
        private Alert alert;

        public App()
        {
            InitializeComponent();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            // ošetření prvního prázdného vstupu
            if (string.IsNullOrWhiteSpace(tboxPidFirst.Text))
            {
                alert = new Alert(Alert.AlertType.error, $"První pole pro údaje rodného čísla nesmí být prázdné. Mělo by obsahovat hodnoty ve formátu RRMMDD - tedy poslední dvě číslice roku narození, měsíc narození a den narození.", "Chyba!", MessageBoxButtons.OK);
                return;
            }

            // ošetření druhého prázdního vstupu
            if (string.IsNullOrWhiteSpace(tboxPidSecond.Text))
            {
                alert = new Alert(Alert.AlertType.error, $"Pole pro koncovku rodného čísla nesmí být prázdné. Mělo by obsahovat číslo od 0000 do 9999", "Chyba!", MessageBoxButtons.OK);
                return;
            }

            // ošetření zadání krátkého textu v prvním vstupu - platných je pouze 6 znaků (ani víc, ani míň)
            if(tboxPidFirst.TextLength < 6 || tboxPidFirst.TextLength > 6)
            {
                alert = new Alert(Alert.AlertType.error, $"Hodnota prvního pole pro údaje rodného čísla musí být dlouhý PŘESNĚ 6 znaků.", "Chyba!", MessageBoxButtons.OK);
                return;
            }

            // ošetření zadání krátkého textu v druhém vstupu - platné jsou pouze 4 znaky (ani víc, ani míň)
            if (tboxPidSecond.TextLength < 4 || tboxPidSecond.TextLength > 4)
            {
                alert = new Alert(Alert.AlertType.error, $"Hodnota pole pro koncovku rodného čísla musí být dlouhý PŘESNĚ 4 znaky.", "Chyba!", MessageBoxButtons.OK);
                return;
            }

            // ošetření zadání nečíselné hodnoty do prvního vstupu
            if(!int.TryParse(tboxPidFirst.Text, out _))
            {
                alert = new Alert(Alert.AlertType.error, $"Hodnota prvního pole MUSÍ být číeslná. Musí obsahovat šstimístné číslo ve tvaru RRMMDD - tedy poslední dvě číslice roku narození, měsíc narození a den narození.", "Chyba!", MessageBoxButtons.OK);
                return;
            }

            // ošetření zadání nečíselné hodnoty do druhého vstupu
            if (!int.TryParse(tboxPidSecond.Text, out _))
            {
                alert = new Alert(Alert.AlertType.error, $"Hodnota pole koncovky rodného čísla MUSÍ být číeslná. Musí obsahovat čtyřmístné číslo od 0000 do 9999", "Chyba!", MessageBoxButtons.OK);
                return;
            }

            // Pokud žádný z výše použitých ošetření nevyvolá chybu, pokračujeme v programu

            // rozdělení hodnoty prvního vstupu na jednotlivá dvojčíslí
            string[] segmenty = new string[tboxPidFirst.TextLength / 2]; // vytvoření pole pro jednotlivá dvojčíslí

            for (int i = 0; i < tboxPidFirst.TextLength; i += 2)
            {
                segmenty[i / 2] = tboxPidFirst.Text.Substring(i, 2); // Rozdělení čísla na dvojčísla a vložení do pole
            }

            // ošetření zadaného čísla dne, který je větší než možný počet dnů v měsíci (min. 1, max. 31)
            if (int.Parse(segmenty[2]) > 31 || int.Parse(segmenty[2]) <= 1)
            {
                alert = new Alert(Alert.AlertType.error, $"Zadané číslo dne neodpovídá žádnému známému číslu dne v měsíci z 31 dnů.", "Chyba!", MessageBoxButtons.OK);
                return;
            }

            // ošetření zadání záporného čísla roku
            if (int.Parse(segmenty[0]) < 0)
            {
                alert = new Alert(Alert.AlertType.error, $"Zadané číslo roku NESMÍ být menší než 0", "Chyba!", MessageBoxButtons.OK);
                return;
            }

            // ošetření zadání záporného čísla měsíce
            if (int.Parse(segmenty[1]) < 0)
            {
                alert = new Alert(Alert.AlertType.error, $"Zadané číslo měsíce NESMÍ být menší než 0", "Chyba!", MessageBoxButtons.OK);
                return;
            }

            // ošetření zadání záporného čísla dne
            if (int.Parse(segmenty[2]) < 0)
            {
                alert = new Alert(Alert.AlertType.error, $"Zadané číslo dne NESMÍ být menší než 0", "Chyba!", MessageBoxButtons.OK);
                return;
            }

            // ověření platnosti koncovky rodného čísla
            if (Int64.Parse($"{int.Parse(tboxPidFirst.Text)}{tboxPidSecond.Text}") % 11 != 0)
            {
                alert = new Alert(Alert.AlertType.error, $"Koncovka rodného čísla není platná", "Chyba!", MessageBoxButtons.OK);
                return;
            }

            // převod posledního dvojčíslí roku na čtyřmístný rok
            if (int.Parse(segmenty[0]) < (int.Parse(DateTime.Today.Year.ToString()) % 100))
            {
                // pokud jsou poslední dvě číslice roku rodného čísla menší, než poslední dvě číslice aktuálního roku, zařdíme rok narození do 21. století
                segmenty[0] = $"20{segmenty[0]}";
            }
            else
            {
                // pokud jsou poslední dvě číslice roku rodného čísla větší, než poslední dvě číslice aktuálního roku, zařadíme rok narození do 20. století
                segmenty[0] = $"19{segmenty[0]}";
            }

            // zjištění, zda je osoba se zaaným rodným číslem muž (M) nebo žena (Ž)
            bool jeZena;

            if (int.Parse(segmenty[1]) - 50 > 0)
            {
                // ošetření zadání nepltatného čísla měsíce pro ženu (min. 51, max. 62)
                if(int.Parse(segmenty[1]) - 50 > 12 || int.Parse(segmenty[1]) - 50 < 1)
                {
                    alert = new Alert(Alert.AlertType.error, $"Zadané číslo pro měsíc NESMÍ musí být větší než 62 a zároveň menší než 51", "Chyba!", MessageBoxButtons.OK);
                    return;
                }

                // pokud je po odečtení 50 od měsíce narození z roného čísla výsledek větší než 0, je osoba žena
                jeZena = true;
                segmenty[1] = (int.Parse(segmenty[1]) - 50).ToString();
            }
            else
            {
                // ošetření zadání nepltatného čísla měsíce pro muže (min. 01, max. 12)
                if (int.Parse(segmenty[1]) > 12 || int.Parse(segmenty[1]) < 1)
                {
                    alert = new Alert(Alert.AlertType.error, $"Zadané číslo pro měsíc NESMÍ musí být větší než 12 a zároveň menší než 1", "Chyba!", MessageBoxButtons.OK);
                    return;
                }

                // pokud je po odečtení 50 od měsíce narození z rodného čísla výsledek menší než 0, je osoba muž
                jeZena = false;
            }

            if (jeZena)
            {
                // pokud je osoba žena
                alert = new Alert(Alert.AlertType.info, $"Osoba, které patří toto rodné číslo, je žena, narozená {segmenty[2]}. {segmenty[1]}. {segmenty[0]}", "Výsledek", MessageBoxButtons.OK);
            }
            else
            {
                // pokud je osoba muž
                alert = new Alert(Alert.AlertType.info, $"Osoba, které patří toto rodné číslo, je muž, narozený {segmenty[2]}. {segmenty[1]}. {segmenty[0]}", "Výsledek", MessageBoxButtons.OK);
            }
        }

        private void App_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            alert = new Alert(Alert.AlertType.info, $"Aplikace CzechPinVerifier\n2023 © Petr Vurm\n\nVytvořeno jako dobrovolný úkol z předmětu PROGRAMOVÁNÍ na SPŠ Hradební.", "O aplikaci", MessageBoxButtons.OK);
        }
    }
}