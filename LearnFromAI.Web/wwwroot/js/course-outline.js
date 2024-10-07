export function initializeCourseOutline(courseId, currentSubjectId, currentExerciseId) {
    document.addEventListener('DOMContentLoaded', () => {
        fetchCourseOutline(courseId)
            .then(course => {
                updateDOM(course, currentSubjectId, currentExerciseId);
            })
            .catch(error => {
                console.error('Error fetching course outline:', error);
                showErrorMessage();
            });
    });
}

export async function fetchCourseOutline(courseId) {
    const response = await fetch(`/api/Courses/${courseId}`);
    if (!response.ok) {
        throw new Error('Network response was not ok');
    }
    return response.json();
}

export function renderCourseOutline(course, currentSubjectId, currentExerciseId) {
    let html = '<ul class="space-y-2">';
    course.subjects.forEach(subject => {
        const isActiveSubject = subject.id === currentSubjectId;
        html += `
            <li>
                <a href="/Subject/${subject.id}" class="${isActiveSubject ? 'font-bold' : ''} hover:text-primary">
                    ${subject.headline}
                </a>
                ${renderExercises(subject.exercises, currentExerciseId, isActiveSubject)}
            </li>
        `;
    });
    html += '</ul>';
    return html;
}

export function renderExercises(exercises, currentExerciseId, isActiveSubject) {
    if (!exercises || exercises.length === 0) return '';

    let html = '<ul class="ml-4 mt-1 space-y-1">';
    exercises.forEach(exercise => {
        const isActiveExercise = exercise.id === currentExerciseId;
        html += `
            <li>
                <a href="/Exercise/${exercise.id}" class="${isActiveExercise ? 'font-bold' : ''} hover:text-primary">
                    ${exercise.headline}
                </a>
            </li>
        `;
    });
    html += '</ul>';
    return html;
}

export function getNavigationItems(course) {
    let items = [];
    course.subjects.forEach(subject => {
        items.push({ type: 'subject', id: subject.id });
        subject.exercises.forEach(exercise => {
            items.push({ type: 'exercise', id: exercise.id });
        });
    });
    return items;
}

export function getNavigationUrls(items, currentIndex) {
    const prevUrl = currentIndex > 0 ? getUrlForItem(items[currentIndex - 1]) : null;
    const nextUrl = currentIndex < items.length - 1 ? getUrlForItem(items[currentIndex + 1]) : null;
    return { prevUrl, nextUrl };
}

function getUrlForItem(item) {
    return item.type === 'subject' ? `/Subject/${item.id}` : `/Exercise/${item.id}`;
}

function updateDOM(course, currentSubjectId, currentExerciseId) {
    const outlineHtml = renderCourseOutline(course, currentSubjectId, currentExerciseId);
    document.getElementById('courseOutline').innerHTML = outlineHtml;

    const items = getNavigationItems(course);
    const currentIndex = items.findIndex(item =>
        (item.type === 'subject' && item.id === currentSubjectId) ||
        (item.type === 'exercise' && item.id === currentExerciseId)
    );
    const { prevUrl, nextUrl } = getNavigationUrls(items, currentIndex);

    updateNavigationButton('prevButton', prevUrl);
    updateNavigationButton('nextButton', nextUrl);
}

function updateNavigationButton(buttonId, url) {
    const button = document.getElementById(buttonId);
    if (url) {
        button.href = url;
        button.classList.remove('invisible');
    } else {
        button.classList.add('invisible');
    }
}

function showErrorMessage() {
    document.getElementById('courseOutline').innerHTML = '<p class="text-red-500">Error loading course outline. Please try again later.</p>';
}
