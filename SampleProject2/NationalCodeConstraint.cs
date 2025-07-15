namespace SampleProject2
{
    public class NationalCodeConstraint : IRouteConstraint
    {

        public bool Match(HttpContext httpContext,IRouter route,string routeKey,RouteValueDictionary values,RouteDirection routeDirection)
        {
            var nationalCode = values[routeKey].ToString();
            bool res = false;

            if (string.IsNullOrWhiteSpace(nationalCode) || nationalCode.Length != 10)
                res= false;

            var check = int.Parse(nationalCode[9].ToString());
            var sum = 0;
            for (int i = 0; i < 9; i++)
                sum += int.Parse(nationalCode[i].ToString()) * (10 - i);

            var remainder = sum % 11;
            res= (remainder < 2 && check == remainder) || (remainder >= 2 && check + remainder == 11);

            return res;
        }

     
    }

}