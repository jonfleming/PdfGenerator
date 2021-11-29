# PDF Generator

### ASP.NET service to convert HTML to PDF using Winnovative HTML to PDF Converter

To convert HTML to PDF:
1. Set the environment variable __HtmlToPdfLicense__ to your Winnovative license key
   or use the demo key "fvDh8eDx4fHg4P/h8eLg/+Dj/+jo6Og="
2. Open solution in VS 2019
3. Add "wnvhtmltopdf.dll" from the root of the project to References
4. Run locally using IIS Express
5. Send a POST request containing HTML in the body of the request

```
curl --location --request POST 'https://localhost:44336/api/PdfGenerator' \
--header 'Content-Type: text/plain' \
--data-raw '<html><body>This is a test</body></html>'
```

## Postman
Method: POST
URL: https://localhost:44336/api/PdfGenerator
Headers: Content-Type: text/plain
Body:
```
<html>
  <body>
    This is a test
  </body>
</html
```
You can click the dropdown next to Send and select "Send and Download" to be prompted for a filename to save the PDF response.

## Javascript
Using Axios
```
async function generatePdf() {
  // Get innerHtml from Pdf.vue
  const element = document.getElementById('pdf')
  const htmlString = element ? element.innerHTML : ''

  try {
    const config = {
      responseType: 'blob',
      headers: {
        'Content-Type': 'text/plain',
      },
    }
    const pdf = await axios.post(
      'https://localhost:44336/api/PdfGenerator?filename=file.pdf',
      htmlString,
      config
    )

    const file = new Blob([pdf.data], { type: 'application/pdf' })
    const fileURL = URL.createObjectURL(file)
    window.open(fileURL)
  } catch (err) {
    console.error(err)
  }
}
```