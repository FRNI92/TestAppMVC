document.querySelector("#mini-menu-dark-mode-toggle").addEventListener("click", function () {
    const htmlElement = document.documentElement;

    if (htmlElement.getAttribute("data-theme") === "dark") {
        htmlElement.setAttribute("data-theme", "light");
    } else {
        htmlElement.setAttribute("data-theme", "dark");
    }
});
// document.querySelector connects to id dark-mode-toggle
// addEventLister listener for a click-event.
//gets the html element to be able to modify the attribut, it saves it in a const called htmlElement
//if the html has a attribute called data-theme and it is set to dark, then it will set data-theme to light
//if its not dark it will set it to dark:



const miniMenuCard = document.querySelector(".mini-menu-card");//Selects the mini menu card element from the HTML
const menuTriggers = document.querySelectorAll(".menu-trigger");// when using several triggers like gear and avatar. selects all element with that class

//iterates through all menu-triggers and adds click even listener to each
menuTriggers.forEach(trigger => {
    trigger.addEventListener("click", function (event) {//added event and stop propagation to be able to get the menu to show. could also use "&& !event.target.closest(".menu-trigger")" on line 30 after target
        event.stopPropagation();
        miniMenuCard.classList.toggle("show"); // toggles between the show and ''
    });
});

document.addEventListener("click", function (event) {//event is an object that contains info of the click, like what element was clicked on
    if (!miniMenuCard.contains(event.target)) {
        miniMenuCard.classList.remove("show"); // if I click outside the menu it will remove show
    }
});


//open modal
document.addEventListener('DOMContentLoaded', () => {
    const modalButtons = document.querySelectorAll('[data-modal="true"]')
    modalButtons.forEach(button => {
        button.addEventListener('click', () => {

        const modalTarget = button.getAttribute('data-target')
        const modal = document.querySelector(modalTarget)

        if (modal)
            modal.style.display = 'flex'
        })
    })
    //open modal

    //close modal
    const closeButtons = document.querySelectorAll('[data-close="true"]')
    closeButtons.forEach(button => {
        button.addEventListener('click', () => {
            const modal = button.closest('.modal')
            if (modal) {
                modal.style.display = 'none'

                //clear formdata
                modal.querySelectorAll('form').forEach(form => {
                    form.reset()

                    const imagePreview = form.querySelector('.image-preview')
                    if (imagePreview)
                        imagePreview.src = ''
                    const imagePreviewer = form.querySelector('.image-previewer')
                    if (imagePreviewer)
                        imagePreviewer.classList.remove('selected')
                })
            }
        })
    })
    //close modal
    const previewSize = 150


    // handle image-previewer
    document.querySelectorAll('.image-previewer').forEach(previewer => {
        const fileInput = previewer.querySelector('input[type="file"]');
        const imagePreview = previewer.querySelector('.image-preview');

        previewer.addEventListener('click', () => fileInput.click());

        fileInput.addEventListener('change', ({ target: { files } }) => {
            const file = files[0]
            if (file)
                processImage(file, imagePreview, previewer, previewSize)

        })    // handle image-previewer

        // handle submit forms
        const forms = document.querySelectorAll('form')
        forms.forEach(form => {
            form.addEventListener('submit', async (e) => {
                e.preventDefault()

                clearErrorMessages(form)
                const formData = new FormData(form)

                try {
                    const res = await fetch(form.action, {
                        method: 'post',
                        body: formData
                    })

                    if (res.ok) {
                        const modal = form.closest('.modal')
                        if (modal)
                            modal.style.display = 'none';

                        window.llocation.reload()
                    }

                    else if(res.status === 400) {
                        const data = await res.json()

                        if (data.errors) {
                            Object.keys(data.errors).forEach(key => {

                                let input = form.querySelector(`[name="${key}"]`)
                                if (input) {
                                    input.classList.add('input-validation-error')
                                }

                                let span = form.querySelector(`[data-valmsg-for="${key}"]`)
                                if (span) {
                                    span.innerText = data.errors[key].join('\n');
                                    span.classList.add('field-validation-error')
                                }

                            })
                        }
                    }
                }
                catch {
                    console.log('error submitting form')
                }
            })
        })


    });
    // handle submit forms
    function clearErrorMessages(form) {
        form.querySelectorAll('[data-val="true"]').forEach(input => {
            input.classList.remove('input-validation-error')
        })
                             
        form.querySelectorAll('[data-valmsg-for]').forEach(span => {
            span.innerText = ''
            span.classList.remove('field-validation-error')
        })
    }// handle submit forms


    function addErrorMessages(key, errorMessage) {

    }



    // image preview
    async function loadImage(file) {//needs to be async
        return new Promise((resolve, reject) => {
            const reader = new FileReader()

            reader.onerror = () => reject(new Error("Failed to load file."))
            reader.onload = (e) => {
                const img = new Image()
                img.onerror = () => reject(new Error("failed to load image"))
                img.onload = () => resolve(img)
                img.src = e.target.result
            }
            reader.readAsDataURL(file)
        })
    }


    async function processImage(file, imagePreview, previewer, previewSize = 150) {
        try {
            const img = await loadImage(file)
            const canvas = document.createElement('canvas')
            canvas.width = previewSize
            canvas.height = previewSize

            const ctx = canvas.getContext('2d')
            ctx.drawImage(img, 0, 0, previewSize, previewSize)
            imagePreview.src = canvas.toDataURL('image/jpeg')
            previewer.classList.add('selected')
        }
        catch (error) {
            console.error('failed on image-processing:')
        }
    }

})