using System;
using System.Text.RegularExpressions;

public class ValidadeInfo {

    /// <summary>
    /// Faz a validação do email.
    /// </summary>
    /// <param name="email">Email a ser validado.</param>
    /// <returns>Retorna se o email passado é valido "true" ou não "false".</returns>
    public static bool ValidadeEmail(string email) {
        //^([0-9A-Za-z]([-.\w]*[0-9A-z])*@([0-9A-z][-\w]*[0-9A-z]\.)+[a-zA-Z]{2,9})$
        string strPattern = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";

        if (Regex.IsMatch(email, strPattern)) {
            return true;
        } else {
            return false;
        }
    }

    /// <summary>
    /// Faz a validação da data de nascimento.
    /// </summary>
    /// <param name="birdDate">Data a ser validada</param>
    /// <returns>Retorna se a data digitada é validada "true" ou não "false".</returns>
    public static bool ValidadeBirthDate(string birhdDate) {
        string strPattern = @"^(\d{2})\/(\d{2})\/(\d+)";

        if (Regex.IsMatch(birhdDate, strPattern)) {
            //Se falhar na hora de transforma quer dizer que a data é invalida. Não se usou o TryParse, pois se passar uma data invalida ele retora
            //01/01/0001, que é uma data valida, ai não se fica sabendo se o usuário digitou essa data ou deu erro na hora de converter o texto em data.
            try {
                if (DateTime.Compare(DateTime.Now.Date, DateTime.Parse(birhdDate)) >= 0) {
                    return true;
                } else {
                    return false;
                }
            } catch {
                return false;
            }
        } else {
            return false;
        }
    }
}
